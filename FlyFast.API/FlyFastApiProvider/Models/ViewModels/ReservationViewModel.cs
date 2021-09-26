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
        public string Date { get; set; }

        [Required]
        [Display(Description ="Nom de votre entreprise ")]
        public string Company { get; set; }
    }
}