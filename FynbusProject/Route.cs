using System.Collections.Generic;
using System.Linq;

namespace FynbusProject
{
    public class Route
    {
        // Contract period in years
        private int _contractPeriod = 2;
        public int RouteNumber { get; private set; }
        public int VehicleType { get; private set; }
        public int RoutePriority { get; set; }
        public int AvaliabilityPeriodWeekDays { get; set; }
        //Amount of hours that the flex vehicle is avaliable during a day in the weekend 
        public int AvaliabilityPeriodWeekends { get; set; }
        //Amount of hours that the flex vehicle is avaliable during a day that's a holiday
        public int AvaliabilityPeriodHolidays { get; set; }
        // Amount of days for the contract period
        private int _amountOfHolidays;
        private int _amountOfWeekDays;
        private int _amountOfWeekendsDays;

        public int AmountOfHoursContractPeriod()
        {
            //Calculates the available hours needed for a specific route object
            return ((AvaliabilityPeriodWeekDays * _amountOfWeekDays) +
                   (AvaliabilityPeriodHolidays * _amountOfHolidays) +
                   (AvaliabilityPeriodWeekends * _amountOfWeekendsDays));
        }

        // Will store winning offer once it's been calculated
        public Offer WinningOffer { get; set; }

        public List<Offer> ListOfOffers { get; private set; }

        private Offer _noWinnerOffer;

        public Route(int routeNb, int vehType, int hoursWeekdays, int hoursWeekends, int hoursHolidays)
        {
            RouteNumber = routeNb;
            VehicleType = vehType;
            ListOfOffers = new List<Offer>();
            AvaliabilityPeriodHolidays = hoursHolidays;
            AvaliabilityPeriodWeekDays = hoursWeekdays;
            AvaliabilityPeriodWeekends = hoursWeekends;
            _amountOfHolidays = 14 * _contractPeriod;
            _amountOfWeekDays = 261 * _contractPeriod;
            _amountOfWeekendsDays = 100 * _contractPeriod;
            _noWinnerOffer = new Offer("", this, 0, new Contractor("", "No winner", "", "", 0, 0, 0, 0, 0), 0);
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
                diff = ListOfOffers[1].ContractValue -
                       ListOfOffers[0].ContractValue;
            }
            // Uncomment this if you want to prioritize list of offer
            /*if (ListOfOffers.Count == 1)
            {
                diff = 10000000000000000000;
            }
            */
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
                WinningOffer = _noWinnerOffer;
            }

        }

        public bool FirstOfferHasVehicleLeft()
        {
            bool HasVehicle = false;
            if (ListOfOffers.Count > 0)
            {
                HasVehicle = ListOfOffers[0].HasVehicleOfVehType(VehicleType);
            }
            return HasVehicle;
        }
    }
}
