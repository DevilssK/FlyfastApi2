using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models.ExternalModels
{
    public class ExTrip
    {
        [JsonProperty("flight")]
        public ExFlight Flight { get; set; }

        [JsonProperty("availability")]
        public int Availability { get; set; }


    }
}