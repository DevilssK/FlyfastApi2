using System;
using System.Collections.Generic;
using System.Text;

namespace FlyFast.ModelAPI
{
    public class FeesViewModel
    {
        public string CompanyName { get; set; }
        public float PriceEur { get; set; }
        public float PriceUsd { get; set; }
        public DateTime LastOrderDateTime { get; set; }
    }
}
