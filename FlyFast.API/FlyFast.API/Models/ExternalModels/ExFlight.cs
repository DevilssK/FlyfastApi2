using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class ExFlight
    {
        [JsonProperty("code")]
        public string Code { get; set; }


        [JsonProperty("departure")]
        public string departure { get; set; }


        [JsonProperty("arrival")]
        public string arrival { get; set; }


        [JsonProperty("base_price")]
        public int basePrice { get; set; }


        public ExPlane plane { get; set; }


        public int seat_Booked { get; set; }

        public DateTime DepartureDate { get; set; }
    }
}
