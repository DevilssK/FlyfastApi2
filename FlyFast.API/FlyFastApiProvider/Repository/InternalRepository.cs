using FlyFastApiProvider.Models;
using FlyFastApiProvider.Models.ViewModels;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FlyFastApiProvider.Repository
{
    public class InternalRepository : IDisposable
    {

        #region [Logger]
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion


        const string URL_INTERNAL = "http://nelsonintech-001-site1.itempurl.com";

        public async Task<List<Trip>> GetTravelJson(DateTime Date)
        {
            List<Trip> trips = new List<Trip>() ;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync($"{URL_INTERNAL}/TravelsCache/?date={Date.ToString("yyyy-MM-dd")}");

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    trips = JsonConvert.DeserializeObject<List<Trip>>(body);

                  
                }
            }

            return trips;
        }

        public async Task<ReservationViewModel> GetFees(string Company, int Month, int Year)
        {
            ReservationViewModel reservationViewModel = new ReservationViewModel();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync($"{URL_INTERNAL}/CompanyFees/?Company={Company}&Month={Month}&{Year}");

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    reservationViewModel = JsonConvert.DeserializeObject<ReservationViewModel>(body);


                }
            }

            return reservationViewModel;
        }

        public string BookJson()
        {
            string travelsJson = string.Empty;

            return travelsJson;
        }

        internal async Task<bool> CreateOrder(ReservationViewModel reservation)
        {
            bool isCreated = false;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    var stringExTicket = JsonConvert.SerializeObject(reservation);

                    var httpContent = new StringContent(stringExTicket, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{URL_INTERNAL}/Book", httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        isCreated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }

            return isCreated;
        }

        public void Dispose()
        {
        }
    }
}