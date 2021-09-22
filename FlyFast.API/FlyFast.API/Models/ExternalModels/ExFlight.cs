using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class ExFlight
    {
        public string Code { get; set; }
        public AIRPORT departure { get; set; }
        public AIRPORT arrival { get; set; }
        public int basePrice { get; set; }
        public ExPlane plane { get; set; }
        public int seat_Booked { get; set; }
    }
}
