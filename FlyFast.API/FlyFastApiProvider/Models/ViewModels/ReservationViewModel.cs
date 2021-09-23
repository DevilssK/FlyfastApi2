using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlyFastApiProvider.Models.ViewModels
{
    public class ReservationViewModel
    {
        [Required]
        public string customerName { get; set; }
        public int tripId { get; set; }
        public List<UserLineViewModel> Lines { get; set; }
        
        [Required]
        public int BasePrice { get; set; }

        [Required]
        public float PriceEUR { get; set; }

        [Required]
        public float PriceUSD { get; set; }

        [Required]
        public string date { get; set; }

        [Required]
        public string company { get; set; }
    }
}