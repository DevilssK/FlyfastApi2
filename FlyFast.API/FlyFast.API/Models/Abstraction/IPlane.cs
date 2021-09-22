using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models.Abstraction
{
    interface IPlane
    {
         List<Customer> _customers { get; set; }
         int IdPlane { get; set; }
         Int32 MaxPlaces { get; set; }
         int NbrPlaceFirstClass { get; set; }
         int NbrPlaceFirstClassRemaining { get; set; }
    }
}