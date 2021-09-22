using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class Trip
    {
        public Trip()
        {
            this.Line = new List<Line>();

        }
        public int Id { get; set; }
       
        public DateTime Date { get; set; }

        public List<Line> Line { get; set; }      

        //public float PriceFirstClass { get; set; }
        //private float _priceSecondClass;

        //public float PriceSecondClass
        //{
        //    get { return _priceSecondClass; }
        //    set
        //    {
        //        _priceSecondClass = value;
        //        this.PriceFirstClass = this.PriceSecondClass * 2;
        //    }
        //}


    }
}