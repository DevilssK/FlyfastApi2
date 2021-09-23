using FlyFast.API.Models;
using FlyFast.API.Models.ExternalModels;
using FlyFast.API.Models.ViewModels;
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

namespace FlyFast.API.Repository
{
    public class ExternalProfRepository : IDisposable
    {
        #region [Logger]
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        const string URL_API_PROF = "https://api-6yfe7nq4sq-uc.a.run.app";
        public  string External_Name = "PROF_COMPANY";
        const float COMMISSION_PERCENTAGE = 10;


        public async Task<List<ExTrip>> GetExFlights(DateTime date)
        {
            List<ExTrip> exFlights = new List<ExTrip>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = await client.GetAsync($"{URL_API_PROF}/flights/{date.ToString("dd-MM-yyy")}");

                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();

                        exFlights = JsonConvert.DeserializeObject<List<ExTrip>>(body);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }

            foreach (var exFlight in exFlights)
            {
                exFlight.Flight.DepartureDate = date;

                exFlight.Flight.plane.Options = new List<ExOptions>();
                exFlight.Flight.plane.Options = await GetExOptions(exFlight.Flight.Code);
            }

            return exFlights;
        }

        public async Task<List<ExOptions>> GetExOptions(string Code)
        {
            List<ExOptions> exOptions = new List<ExOptions>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = await client.GetAsync($"{URL_API_PROF}/available_options/{Code}");

                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();

                        exOptions = JsonConvert.DeserializeObject<List<ExOptions>>(body);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }

            return exOptions;
        }


        public async Task<bool> PostExBook(ReservationViewModel reservationViewModel)
        {
            bool isBooked = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();           

                    var stringExTicket = JsonConvert.SerializeObject(reservationViewModel);

                    var httpContent = new StringContent(stringExTicket, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{URL_API_PROF}/book/", httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        isBooked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }

            return isBooked;
        }


        public List<Trip> GetTripExternal(List<ExTrip> exTrips)
        {
            List<Trip> trips = new List<Trip>();

            foreach (var extrip in exTrips)
            {
                Trip trip = new Trip();
                trip.Company = External_Name;
                trip.Date = extrip.Flight.DepartureDate;
                trip.Id = CACHE.GenerateIdTrip;

                trip.Line = new List<Line>();

                Line line = new Line();
                line.Id = CACHE.GenerateIdLine;
                line.Date = extrip.Flight.DepartureDate;
                line.Departure = extrip.Flight.departure;
                line.Arrived = extrip.Flight.arrival;
                line.BasePrice = extrip.Flight.basePrice;
                line.CommissionPercentage = COMMISSION_PERCENTAGE;
                line.Price = (extrip.Flight.basePrice * (100 + line.CommissionPercentage)) / 100;

                line.Plane = new Plane();
                line.Plane.Name = extrip.Flight.plane.name;
                line.Plane.MaxPlaces = extrip.Flight.plane.total_seat;

                if (extrip.Flight.plane.Options.Where(w => w.optionsType == "FirstClass").Count() > 0)
                {
                    line.Plane.NbrPlaceFirstClass = extrip.Flight.plane.total_seat;
                }


                line.Plane.Options = new List<Option>();

                foreach (var option in extrip.Flight.plane.Options)
                {
                    Option anOption = new Option();
                    anOption.Name = option.optionsType;
                    anOption.Price = option.price;
                    line.Plane.Options.Add(anOption);
                }

                trip.Line.Add(line);
                trips.Add(trip);
            }

            return trips;
        }


        public void Dispose()
        {
        }
    }
}