using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFastApiProvider.Models
{
    public class Trip
    {
        public Trip()
        {
            this.Company = "FLY_FAST_COMPANY";
            this.Line = new List<Line>();

        }
        public int Id { get; set; }
       
        public DateTime Date { get; set; }

        public List<Line> Line { get; set; }
        public string Company { get; internal set; }

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