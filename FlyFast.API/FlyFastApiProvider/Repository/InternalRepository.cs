using FlyFastApiProvider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FlyFastApiProvider.Repository
{
    public class InternalRepository : IDisposable
    {
        const string URL_INTERNAL = "http://nelsonintech-001-site1.itempurl.com";

        public async Task<List<Trip>> GetTravelJson(DateTime Date)
        {
            List<Trip> trips = new List<Trip>() ;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync($"{URL_INTERNAL}/Travels/?date={Date.ToString("yyyy-MM-dd")}");

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    trips = JsonConvert.DeserializeObject<List<Trip>>(body);
                }
            }

            return trips;
        }

        public string BookJson()
        {
            string travelsJson = string.Empty;

            return travelsJson;
        }

        public void Dispose()
        {
        }
    }
}