using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFastApiProvider.Models.ViewModels
{
    public class FeesViewModel
    {
        public string Company { get; set; }

        public float FeesEur { get; set; }

        public float FeesUsd { get; set; }

        public float SalesPriceEur { get; set; }

        public float SalesPriceUsd { get; set; }

        public DateTime DateLastOrder { get; set; }


        public float Commission { get; set; }

        public bool IsBilled { get; set; }
    }
}