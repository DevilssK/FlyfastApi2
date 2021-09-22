using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class Plane
    {
        private List<Customer> _customers;
        private int _nbrPlaceFirstClass;

        public Plane()
        {
            this.Customers = new List<Customer>();
        }

        public int IdPlane { get; set; }
        public Int32 MaxPlaces { get; set; }
       // public int NbrPlaceFirstClass { get; set; }

        public int NbrPlaceFirstClassRemaining { get; set; }

        public int NbrPlaceFirstClass
        {
            get { return _nbrPlaceFirstClass; }
            set
            {
                _nbrPlaceFirstClass = value;
                NbrPlaceFirstClassRemaining = _nbrPlaceFirstClass - this._customers.Where(d => d.TickerType == TICKET_TYPE.FIRST_CLASS).Count();
            }
        }

        public List<Customer> Customers
        {
            get { return _customers; }
            set {
                _customers = value;
                NbrPlaceFirstClassRemaining = this.NbrPlaceFirstClass -  this._customers.Where(d => d.TickerType == TICKET_TYPE.FIRST_CLASS).Count();
            }
        }

    }
}