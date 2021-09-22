using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models.ExternalModels
{
    public class ExTicket
    {
        public string code { get; set; }
        public ExFlight flight { get; set; }
        public string date { get; set; }
        public int payed_price { get; set; }
        public string customer_name { get; set;  }
        public string customer_nationality { get; set; }
        public List<ExOptions> options { get; set; }
        public string booking_source { get; set;  }
    }
}

