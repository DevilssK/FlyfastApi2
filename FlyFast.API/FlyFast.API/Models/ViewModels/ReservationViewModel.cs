using System;
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
        public List<TICKET_TYPE> ticketTypes { get; set; }
        public float PriceEUR { get; set; }
        public float PriceUSD { get; set; }
    }
}