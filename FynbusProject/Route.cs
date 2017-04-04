using System;
using System.Collections.Generic;
using System.Linq;

namespace FynbusProject
{
    public class Route
    {
        public int RouteNumber { get; private set; }
        public int VehicleType { get; private set; }
        // Will store winning offer once it's been calculated
        public Offer WinningOffer { get; set; }

        private Offer _firstOffer = null;
        private Offer _secondOffer = null;

        public List<Offer> ListOfOffers { get; private set; }

        public Route(int routeNb, int vehType)
        {
            RouteNumber = routeNb;
            VehicleType = vehType;
            ListOfOffers = new List<Offer>();
        }

        public bool HasWinner()
        {
            // If the winning offer is null will return false
            return WinningOffer != null;
        }

        public void AddToList(Offer o)
        {
            ListOfOffers.Add(o);
        }
        public void SortListOfOffers()
        {
            List<Offer> sorted = ListOfOffers.OrderBy(o => o.Price).ThenBy(p => p.Priority).ToList();
            ListOfOffers = sorted;
        }

        public bool HasValidOffer(int vehType)
        {
            bool hasValidOffer = false;
            if (_firstOffer != null && _secondOffer != null)
            {
                hasValidOffer = _firstOffer.HasVehicleOfVehType(vehType) && _secondOffer.HasVehicleOfVehType(vehType);
            }
            if (_firstOffer == null && _secondOffer == null)
            {
                Console.WriteLine("Fuck u ");
                //throw new Exception("Error: Route doesn't have any valid offers!");
            }
            if (_firstOffer != null && _secondOffer == null)
            {
                hasValidOffer = _firstOffer.HasVehicleOfVehType(vehType);
            }
            // Returns true if both offers has vehicles left of the vehtype
            return hasValidOffer;
        }

        public void SetFirstAndSecondHighestValidOffer()
        {
            Console.WriteLine("Setting valid offers for" + RouteNumber);
            if (!HasWinner())
            {
                _firstOffer = null;
                _secondOffer = null;

                // Finds the first and second highest offers with vehicles left

                foreach (Offer o in ListOfOffers)
                {
                    if (o.HasVehicleOfVehType(VehicleType))
                    {
                        Console.WriteLine("Is true");
                        if (_firstOffer == null)
                        {
                            Console.WriteLine("Set first offer");
                            _firstOffer = o;
                        }
                        else
                        {
                            if (_secondOffer == null)
                            {
                                Console.WriteLine("Set second offer");
                                _secondOffer = o;
                            }
                        }

                    }
                }
            }
        }

        public double GetDifference()
        {
            SetFirstAndSecondHighestValidOffer();
            double difference = 0;
            if (_firstOffer != null && _secondOffer != null)
            {
                difference = _firstOffer.Price - _secondOffer.Price;
            }
            else
            {
                difference = 0;
            }
            return difference;
        }

        public override bool Equals(object obj)
        {
            Route r = (Route)obj;
            // Returns true if both RouteNumber and VehicleType of the object we are passing and the this. route object are the same 
            return (r.RouteNumber == this.RouteNumber &&
                r.VehicleType == this.VehicleType);
        }
        public override string ToString()
        {
            return RouteNumber + " " + VehicleType;
        }

        public void SetWinningOffer()
        {
            WinningOffer = _firstOffer;
        }
    }
}
