using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFastApiProvider.Models
{
    public class Plane
    {
        //private List<Customer> _customers;
        private int _nbrPlaceFirstClass;

        public Plane()
        {
          //  this.Customers = new List<Customer>();
        }

        public string Name { get; set; }
        public int IdPlane { get; set; }
        public Int32 MaxPlaces { get; set; }
        // public int NbrPlaceFirstClass { get; set; }

        public List<Option> Options { get; set; }

        public int NbrPlaceFirstClassRemaining { get; set; }

        public int NbrPlaceFirstClass
        {
            get { return _nbrPlaceFirstClass; }
            set
            {
                _nbrPlaceFirstClass = value;
                
            }
        }

     

    }
}