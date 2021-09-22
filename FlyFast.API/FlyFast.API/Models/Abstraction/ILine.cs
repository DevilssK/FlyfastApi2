using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models.Abstraction
{
    interface ILine 
    {
         int Id { get; set; }
         string Departure { get; set; }
         string Arrived { get; set; }
         Plane Plane { get; set; }
         float Price { get; set; }
         DateTime Date { get; set; }

    }
}