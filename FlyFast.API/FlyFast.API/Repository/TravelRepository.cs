using FlyFast.API.Models;
using FlyFast.API.Models.ViewModels;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace FlyFast.API.Repository
{
    public class TravelRepository : IDisposable
    {
        #region [Logger]
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        public void Dispose()
        {

        }

        public void LoadData()
        {



            for (int i = 0; i < 30; i++)
            {
                CACHE.Trips.Add(new Trip()
                {
                    Id = CACHE.GenerateIdTrip,
                    Line = new List<Line>()
                {
                  new Line()
                  {
                      Id= CACHE.GenerateIdLine,
                    Departure = AIRPORT.JFK.ToString(),
                    Arrived = AIRPORT.DTW.ToString(),
                    Plane = new Plane() {
                        MaxPlaces = 300,
                        NbrPlaceFirstClass = 0,
                        Options =  new List<Option> (),
                    },
                    Price = 300 * 0.85F,
                    CommissionPercentage = 0,
                    BasePrice = 300 ,
                    Date = DateTime.Now.AddDays(i),
                  },
                  new Line()
                  {
                         Id= CACHE.GenerateIdLine,
                    Departure = AIRPORT.DTW.ToString(),
                    Arrived = AIRPORT.CDG.ToString(),
                    Plane = new Plane() {
                        MaxPlaces = 700,
                        NbrPlaceFirstClass = Convert.ToInt32(700 * 0.1F),
                        Options =  new List<Option>()
                        {
                            new Option()
                            {
                                Name = "FirstClass",
                                Price = (700*100/100) * 0.85F,
                            }
                        }
                    },
                    Price = 700 * 0.85F,
                       CommissionPercentage = 0,
                    BasePrice = 700 ,
                     Date = DateTime.Now.AddDays(i).AddHours(8)
                  }
                }
                  ,
                    Date = DateTime.Now.AddDays(i),
                });


                CACHE.Trips.Add(new Trip()
                {
                    Id = CACHE.GenerateIdTrip,
                    Line = new List<Line>()
                {
                  new Line()
                  {
                         Id= CACHE.GenerateIdLine,
                    Departure = AIRPORT.JFK.ToString(),
                    Arrived = AIRPORT.DTW.ToString(),
                    Plane = new Plane() {
                        MaxPlaces = 300,
                        NbrPlaceFirstClass = 0,
                        Options =  new List<Option> ()
                    },
                    Price = 300,
                       CommissionPercentage = 0,
                    BasePrice = 300 ,
                       Date = DateTime.Now.AddDays(i)
                  }
                },
                    Date = DateTime.Now.AddDays(i),

                });


                CACHE.Trips.Add(new Trip()
                {
                    Id = CACHE.GenerateIdTrip,
                    Line = new List<Line>()
                {
                  new Line()
                  {
                         Id= CACHE.GenerateIdLine,
                    Departure = AIRPORT.CDG.ToString(),
                    Arrived = AIRPORT.DTW.ToString(),
                    Plane = new Plane() {
                        MaxPlaces = 700,
                        NbrPlaceFirstClass = Convert.ToInt32(700 * 0.1F),
                        Options =  new List<Option>()
                        {
                            new Option()
                            {
                                Name = "FirstClass",
                                Price = 700*100/100
                            }
                        }
                    },
                    Price = 700,
                       CommissionPercentage = 0,
                    BasePrice = 700 ,
                       Date = DateTime.Now.AddDays(i)
                  }
                },
                    Date = DateTime.Now.AddDays(i)
                });


                CACHE.Trips.Add(new Trip()
                {
                    Id = CACHE.GenerateIdTrip,
                    Line = new List<Line>()
                {
                  new Line()
                  {
                         Id= CACHE.GenerateIdLine,
                    Departure = AIRPORT.DTW.ToString(),
                    Arrived = AIRPORT.CDG.ToString(),
                    Plane = new Plane() {
                        MaxPlaces = 700,
                        NbrPlaceFirstClass = Convert.ToInt32(700 * 0.1F),
                        Options =  new List<Option>()
                        {
                            new Option()
                            {
                                Name = "FirstClass",
                                Price = 700*100/100
                            }
                        }
                    },
                    Price = 700,
                       CommissionPercentage = 0,
                    BasePrice = 700 ,
                       Date = DateTime.Now.AddDays(i)
                  }
                },
                    Date = DateTime.Now.AddDays(i),
                });



                CACHE.Trips.Add(new Trip()
                {
                    Id = CACHE.GenerateIdTrip,
                    Line = new List<Line>()
                {
                  new Line()
                  {
                         Id= CACHE.GenerateIdLine,
                    Departure = AIRPORT.JFK.ToString(),
                    Arrived = AIRPORT.CDG.ToString(),
                    Plane = new Plane() {
                        MaxPlaces = 1000,
                        NbrPlaceFirstClass = Convert.ToInt32(1000 * 0.1F),
                        Options =  new List<Option>()
                        {
                            new Option()
                            {
                                Name = "FirstClass",
                                Price = 1000*100/100
                            }
                        }
                    },
                    Price = 1000,
                       CommissionPercentage = 0,
                    BasePrice = 1000 ,
                    Date = DateTime.Now.AddDays(i)
                  }
                },
                    Date = DateTime.Now.AddDays(i),
                });


                CACHE.Trips.Add(new Trip()
                {
                    Id = CACHE.GenerateIdTrip,
                    Line = new List<Line>()
                {
                  new Line()
                  {
                    Id=CACHE.GenerateIdLine,
                    Departure = AIRPORT.CDG.ToString(),
                    Arrived = AIRPORT.JFK.ToString(),
                    Plane = new Plane() {
                        MaxPlaces = 1000,
                        NbrPlaceFirstClass = Convert.ToInt32(1000 * 0.1F),
                        Options =  new List<Option>()
                        {
                            new Option()
                            {
                                Name = "FirstClass",
                                Price = 1000*100/100
                            }
                        }
                    },
                    Price = 1000,
                       CommissionPercentage = 0,
                    BasePrice = 1000 ,
                    Date = DateTime.Now.AddDays(i)
                  }
                },
                    Date = DateTime.Now.AddDays(i),
                });

            }



            //========================================================
            // Fake Data Cache Order.
            //========================================================

            CACHE.Orders.Add(new Order()
            {
                priceEUR = 1000,
                customer = new Customer()
                {
                    Name = "toto"
                },
                date = new DateTime(),
                trip = CACHE.Trips[1]

            });

            CACHE.Orders.Add(new Order()
            {
                priceEUR = 1000,
                customer = new Customer()
                {
                    Name = "tutu"
                },
                date = new DateTime(),
                trip = CACHE.Trips[1]

            });

        }

        internal Order CreateExternalOrder(ReservationViewModel reservation, Customer customer)
        {
            Order anOrder = new Order();


            if (reservation.company == (new ExternalProfRepository()).External_Name)
            {
                anOrder = new Order()
                {
                    priceEUR = Convert.ToInt32(reservation.PriceEUR),
                    priceUSD = Convert.ToInt32(reservation.PriceUSD),
                    basePrice = Convert.ToInt32(reservation.BasePrice),
                    date = DateTime.Now,
                    trip = new Trip()
                    {
                        Company = reservation.company
                    },
                    customer = customer
                };
                CACHE.Orders.Add(anOrder);
            }
            return anOrder;
        }


        internal Order CreateOrder(ReservationViewModel reservation, Customer customer)
        {
            List<Line> lines = CACHE.Trips.Where(x => x.Id == reservation.tripId).FirstOrDefault().Line;

            float price = 0;
            if (lines.Count > 1)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    switch (reservation.Lines[i].TicketType)
                    {
                        case (TICKET_TYPE.SECOND_CLASS):
                            price += lines[i].Price;
                            AddCustomerInPlane(customer, lines[i].Plane, reservation.Lines[i].TicketType);

                            break;
                        case (TICKET_TYPE.FIRST_CLASS):
                            price += lines[i].Price * 2;
                            AddCustomerInPlane(customer, lines[i].Plane, reservation.Lines[i].TicketType);
                            break;
                    }
                }

                price = price * 0.85f;
            }
            else
            {
                price = lines.FirstOrDefault().Price;
                AddCustomerInPlane(customer, lines.FirstOrDefault().Plane, reservation.Lines.FirstOrDefault().TicketType);
            }

            Order anOrder = new Order()
            {
                priceEUR = reservation.PriceEUR,
                priceUSD = reservation.PriceUSD,
                basePrice = Convert.ToInt32(reservation.BasePrice),
                company = reservation.company,
                date = DateTime.Now,
                trip = CACHE.Trips.Where(x => x.Id == reservation.tripId).FirstOrDefault(),
                customer = customer
            };
            CACHE.Orders.Add(anOrder);

            return anOrder;
        }

        public void AddCustomerInPlane(Customer customer, Plane plane, TICKET_TYPE type)
        {
            if (type == TICKET_TYPE.FIRST_CLASS)
            {
                int leftPlaces = FirstClassInvalibility(plane);
                if (leftPlaces > 0)
                    plane.Customers.Add(customer);
            }
        }




        public List<Trip> GetTravels()
        {
            List<Trip> trips = new List<Trip>();

            try
            {
                //TODO: Connection BDD.
                trips = CACHE.Trips;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return trips;
        }

        public int PlacesInvalibility(Plane plane)
        {
            int places = plane.MaxPlaces - plane.Customers.Count;
            return places;

        }

        public int FirstClassInvalibility(Plane plane)
        {
            int firstclassCustomers = plane.Customers.Where(x => x.TickerType == TICKET_TYPE.FIRST_CLASS).Count();
            int firstClassPlaces = Convert.ToInt32(plane.MaxPlaces * 0.10);

            return firstClassPlaces - firstclassCustomers;
        }
    }
}