using FlyFastApiProvider.Models;
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
        public async Task<List<Trip>> GetTravels(DateTime Date)
        {
            List<Trip> trips = new List<Trip>(); ;
            using (internalRepository)
            {
                trips = await internalRepository.GetTravelJson(Date);
            }


            return trips;

        }

        // POST: api/ExternalApi
        public void Post([FromBody] string value)
        {
        }


    }
}
