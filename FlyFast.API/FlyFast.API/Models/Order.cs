using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class Order
    {
        public float price { get; set; }
        public Customer customer { get; set; }
        public Trip trip { get; set; }
        public DateTime date { get; set; }

    }
}