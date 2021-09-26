using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlyFastApiProvider.Models.ViewModels
{
    public class FeesRequestViewModel
    {

        [Required]
        public string Company { get; set; }

        [MinLength(2)]
        [MaxLength(2)]
        public int Month { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public int Year { get; set; }
    }
}