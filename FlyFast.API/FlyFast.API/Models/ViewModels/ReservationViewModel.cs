﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models.ViewModels
{
    public class ReservationViewModel
    {
        public string customerName { get; set; }
        public int tripId { get; set; }
        public List<UserLineViewModel> Lines { get; set; }
        public float PriceEUR { get; set; }
        public float PriceUSD { get; set; }
        public string date { get; set; }
        public string company { get; set; }
    }
}