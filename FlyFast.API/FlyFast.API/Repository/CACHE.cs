using FlyFast.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FlyFast.API.Repository
{
    public sealed class CACHE
    {
        public CACHE()
        {
            // Fake Data


        }
        public static List<Trip> Trips = new List<Trip>();

        public static List<Order> Orders = new List<Order>();

        private static List<Devise> _devises;

        public static async Task<List<Devise>> Devises()
        {
            if (_devises == null)
            {
                using (DeviseRepository deviseRepository = new DeviseRepository())
                {
                    _devises =  await deviseRepository.GetDevises();
                }
            }
            else if (_devises.FirstOrDefault().CurrentDate.Date != DateTime.Now.Date)
            {
                using (DeviseRepository deviseRepository = new DeviseRepository())
                {
                    _devises = await  deviseRepository.GetDevises();
                }
            }

            return _devises;

        }


        internal static async Task LoadData()
        {
            using (TravelRepository travelRepository = new TravelRepository())
            {
                travelRepository.LoadData();
            }


            using (DeviseRepository deviseRepository = new DeviseRepository())
            {
                await deviseRepository.GetDevises();
            }
        }
    }
}