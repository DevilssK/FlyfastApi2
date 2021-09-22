using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TICKET_TYPE TickerType { get; set; }
    }
}