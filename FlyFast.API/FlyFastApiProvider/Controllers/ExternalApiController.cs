using FlyFastApiProvider.Models;
using FlyFastApiProvider.Models.ViewModels;
using FlyFastApiProvider.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FlyFastApiProvider.Controllers
{
    public class ExternalApiController : ApiController
    {
        InternalRepository internalRepository = new InternalRepository();

        [HttpGet]
        [Route("Travels")]
        public async Task<IHttpActionResult> GetTravels(DateTime Date)
        {
            if (Date.Date < DateTime.Now.Date)
            {
                return BadRequest($"Votre Date de recherche doit être supérieur à {DateTime.Now.ToString("yyyy-MM-dd")}");
            }

            List<Trip> trips = new List<Trip>(); ;
            using (internalRepository)
            {
                trips = await internalRepository.GetTravelJson(Date);
            }


            return Ok(trips);

        }

        [HttpPost]
        [Route("Book")]
        public async Task<IHttpActionResult> PostReservation(ReservationViewModel reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (internalRepository)
            {
                return Ok(await internalRepository.CreateOrder(reservation));
            }
        }

        [HttpPost]
        [Route("Fees")]
        public async Task<IHttpActionResult> GetFees(FeesRequestViewModel feesRequestViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string dateString = $"{feesRequestViewModel.Year}-{feesRequestViewModel.Month}-31";
            DateTime date = new DateTime();
            bool isADatetime = DateTime.TryParse(dateString, out date);

            if (!isADatetime)
            {
                return BadRequest($"Le mois ({feesRequestViewModel.Month}) ou l'année ({feesRequestViewModel.Year}) est incorrect.");
            }

            using (internalRepository)
            {
                return Ok(await internalRepository.GetFees(feesRequestViewModel.Company , feesRequestViewModel.Month , feesRequestViewModel.Year));
            }
        }


    }
}
