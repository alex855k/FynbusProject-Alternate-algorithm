using System;
using System.Collections.Generic;
using System.Linq;

namespace FynbusProject
{
    public class Route
    {
        public int RouteNumber { get; private set; }
        public int VehicleType { get; private set; }
        public int RoutePriority { get; set; }
        // Will store winning offer once it's been calculated
        public Offer WinningOffer { get; set; }
        public List<Offer> ListOfOffers { get; private set; }

        private Offer NoWinnerOffer = new Offer("", new Route(1, 0), 0, new Contractor("", "No winner", "", "", 0, 0, 0, 0, 0), 0);

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
            List<Offer> sorted = ListOfOffers.FindAll(o => o.HasVehicleOfVehType(this.VehicleType)).OrderBy(o => o.Price).ThenBy(p => p.Priority).ToList();
            ListOfOffers = sorted;
        }

        public double GetTotalContractValueDifference()
        {
            double diff = 0;
            if (ListOfOffers.Count >= 2)
            {
                diff = ListOfOffers[0].ContractValue -
                       ListOfOffers[1].ContractValue;
            }
            if (ListOfOffers.Count == 1)
            {
                diff = 10000000000000000000;
            }
            return diff;
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
            if (ListOfOffers.Count > 0)
            {
                WinningOffer = ListOfOffers[0];
            }
            else
            {
                WinningOffer = NoWinnerOffer;
            }

        }

        public bool FirstOfferHasVehicleLeft()
        {
            bool HasVehicle = false;
            if (ListOfOffers.Count > 0)
            {
                HasVehicle = ListOfOffers[0].HasVehicleOfVehType(VehicleType);
            }
            else
            {
                throw new Exception("Route has no offers left");
            }

            return HasVehicle;
        }
    }
}
