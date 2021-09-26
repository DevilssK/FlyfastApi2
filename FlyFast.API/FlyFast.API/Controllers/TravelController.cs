using FlyFast.API.Models;
using FlyFast.API.Models.ViewModels;
using FlyFast.API.Repository;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FlyFast.API.Controllers
{
    [EnableCors(origins: "http://localhost:4200,https://xenodochial-meitner-2a2721.netlify.app", headers: "*", methods: "*")]
    public class TravelController : ApiController
    {
        #region [Logger]
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        TravelRepository _repository = new TravelRepository();
        DeviseRepository _DeviseRepository = new DeviseRepository();
        ExternalProfRepository externalProfRepository = new ExternalProfRepository();

        [HttpGet]
        [Route("Rate")]
        public async Task<Devise> GetRate(string Devise)
        {
            Devise devise = new Devise();

            devise = (await CACHE.Devises()).Where(x => x.Currency == Devise).FirstOrDefault();

            return devise;

        }

        [HttpGet]
        [Route("Travels")]
        public async Task<List<Trip>> GetListOfTravel()
        {
            List<Trip> trips = new List<Trip>();

            trips = _repository.GetTravels();

            using (externalProfRepository)
            {
                trips.AddRange(externalProfRepository.GetTripExternal(await externalProfRepository.GetExFlights(DateTime.Now.AddDays(1))));
            }

            return trips;
        }

        /// <summary>
        /// Retrived list of Trip by Date.
        /// </summary>
        /// <param name="date">Date of travel</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Travels")]
        public async Task<List<Trip>> GetListOfTravel(DateTime date)
        {
            List<Trip> trips = new List<Trip>();

            trips = _repository.GetTravels();
            var sortedTrip = trips.Where(x => x.Date.Date == date.Date).ToList();

            using (externalProfRepository)
            {
                sortedTrip.AddRange(externalProfRepository.GetTripExternal(await externalProfRepository.GetExFlights(date.Date)));
            }

            return sortedTrip;
        }

        [HttpGet]
        [Route("TravelsCache")]
        public async Task<List<Trip>> GetListOfTravelCache(DateTime date)
        {
            List<Trip> trips = new List<Trip>();

            trips = _repository.GetTravels();
            var sortedTrip = trips.Where(x => x.Date.Date == date.Date).ToList();           

            return sortedTrip;
        }

        [HttpGet]
        [Route("Lines")]
        public List<Line> GetListOfLines()
        {
            List<Line> Lines = new List<Line>();
            foreach (var item in _repository.GetTravels())
            {
                foreach (var line in item.Line)
                {
                    Line oneLine = new Line();
                    oneLine.Id = line.Id;
                    oneLine.Price = line.Price;
                    oneLine.Arrived = line.Arrived;
                    oneLine.Departure = line.Departure;
                    oneLine.Date = line.Date;
                    Lines.Add(oneLine);
                }
            }
            return Lines;
        }

        [HttpGet]
        [Route("Lines")]
        public List<Line> GetListOfLines([FromUri] string date)
        {
            _logger.Debug("================================================================");
            _logger.Debug("Request [Route('Lines')] ");
            _logger.Debug($"Param  : {date}");
            _logger.Debug("================================================================");

            List<Line> Lines = new List<Line>();
            foreach (var item in _repository.GetTravels())
            {
                foreach (var line in item.Line)
                {
                    Line oneLine = new Line();
                    oneLine.Id = line.Id;
                    oneLine.Price = line.Price;
                    oneLine.Arrived = line.Arrived;
                    oneLine.Departure = line.Departure;
                    oneLine.Date = line.Date;
                    Lines.Add(oneLine);
                }
            }

            List<Line> SortedLines = Lines.Where(x => x.Date == Convert.ToDateTime(date)).ToList();
            return SortedLines;
        }


        [HttpGet]
        [Route("Orders")]
        public List<Order> GetOrder(string Username)
        {
            List<Order> orders = null;

            _logger.Debug("================================================================");
            _logger.Debug("Request [Route('Order')] ");
            _logger.Debug($"Param  : {Username}");
            _logger.Debug("================================================================");

            if (CACHE.Orders.Where(w => w.customer.Name == Username).Count() > 0)
            {
                orders = new List<Order>();
                orders = CACHE.Orders.Where(w => w.customer.Name == Username).ToList();
            }

            return orders;
        }

        [HttpGet]
        [Route("CompanyFees")]
        public FeesViewModel GetFeesCompany(string Company, int Month, int Year)
        {
            FeesViewModel feesViewModel = new FeesViewModel();
            feesViewModel.SalesPriceEur  = 0;
            feesViewModel.SalesPriceUsd  = 0;

            List<Order> orders = null;

            _logger.Debug("================================================================");
            _logger.Debug("Request [Route('GetCommissonCompany')] ");
            _logger.Debug($"Param  : {Company}");
            _logger.Debug("================================================================");

            orders = CACHE.Orders.Where(w => w.company == Company && w.date.Year ==  Year  && w.date.Month ==  Month).ToList();

            foreach (var order in orders)
            {
                feesViewModel.SalesPriceEur = order.priceEUR;
                feesViewModel.SalesPriceUsd = order.priceUSD;
            }

            feesViewModel.FeesEur = feesViewModel.SalesPriceEur * 0.05F;
            feesViewModel.FeesUsd = feesViewModel.SalesPriceUsd * 0.05F;
            feesViewModel.Company = Company;

            feesViewModel.Commission = 0.05F;

            var lastOrder = orders.OrderBy(o => o.date).FirstOrDefault();

            feesViewModel.DateLastOrder = lastOrder.date;

            feesViewModel.IsBilled = false;
            if (DateTime.Now.Year > Year && DateTime.Now.Month > Month)
            {
                feesViewModel.IsBilled = true;
            }           

            return feesViewModel;
        }

        [HttpPost]
        [Route("Book")]
        public async Task<IHttpActionResult> PostReservation(ReservationViewModel reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.Debug("================================================================");
            _logger.Debug("Request [Route('Book')] ");
            _logger.Debug($"ViewModel en param  : {Newtonsoft.Json.JsonConvert.SerializeObject(reservation)}");
            _logger.Debug("================================================================");

            Customer customer = new Customer();
            customer.Name = reservation.customerName;
            if (reservation.company == "FLY_FAST_COMPANY")
            {
                return Ok(_repository.CreateOrder(reservation, customer));
            }
            else
            {
                try
                {
                   await externalProfRepository.PostExBook(reservation);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }

                return Ok(_repository.CreateExternalOrder(reservation, customer));
            }
        }


    }
}