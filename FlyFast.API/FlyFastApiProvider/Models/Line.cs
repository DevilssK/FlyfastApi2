using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFastApiProvider.Models
{
    public class Line
    {
        public Line()
        {

        }

        public int Id { get; set; }
        public string Departure { get; set; }
        public string Arrived { get; set; }
        public Plane Plane { get; set; }
        public float Price { get; set; }
        public float BasePrice { get; set; }
        public float CommissionPercentage { get; set; }
        public DateTime Date { get; set; }
    }
}