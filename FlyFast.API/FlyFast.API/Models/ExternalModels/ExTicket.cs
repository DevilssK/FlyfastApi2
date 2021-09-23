using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models.ExternalModels
{
    public class ExTicket
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("flight")]
        public ExFlight flight { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("payed_price")]
        public int payed_price { get; set; }

        [JsonProperty("customer_name")]
        public string customer_name { get; set;  }

        [JsonProperty("customer_name")]  
        public string customer_nationality { get; set; }

        [JsonProperty("options")]
        public List<ExOptions> options { get; set; }

        [JsonProperty("booking_source")]
        public string booking_source { get; set;  }
    }
}

