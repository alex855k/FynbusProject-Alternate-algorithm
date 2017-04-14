using System.Collections.Generic;
using FynbusProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FynbusTests
{
    [TestClass]
    public class CalculateWinnerTests
    {

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void CalculateTotalContractValue()
        {
            Contractor contractor = new Contractor("jan-1", "Company 1", "Eddie Murphy", "Eddie@gmail.com", 1, 2, 2, 3, 4);

            // Fixed vehicles avaliability in hours on a single day for each of the type of days           
            int avaliabilityPeriodWeekDays = 2;
            int avaliabilityPeriodHolidays = 8;
            int avaliabilityPeriodWeekends = 0;

            double price = 250; 

            Route r = new Route(1, 2,avaliabilityPeriodWeekDays,avaliabilityPeriodWeekends,avaliabilityPeriodHolidays);
        
            r.ListOfOffers.Add(new Offer("Jan-1", r, price, contractor, 10));
            
            // *** Fixed values for routes ***

            //Contract period in years
            int contractPeriod = 2;

            // Amount of days for each category over the contractperiod
            int amountOfHolidays = 14 * contractPeriod;
            int amountOfWeekDays = 261 * contractPeriod;
            int amountOfWeekendsDays = 72 * contractPeriod;

            // Calculating the total amount of hours
            int totalAmountOfHours = (avaliabilityPeriodWeekDays * amountOfWeekDays) +
                (avaliabilityPeriodHolidays * amountOfHolidays) +
                (avaliabilityPeriodWeekends * amountOfWeekendsDays);

            // Calculating the total contract value
            double totalContractValue = totalAmountOfHours * price;

            //Assertions

            // Hours 
            Assert.AreEqual(totalAmountOfHours, r.AmountOfHoursContractPeriod());

            // Total contract value 
            Assert.AreEqual(r.ListOfOffers[0].ContractValue, totalContractValue);
        }

        [TestMethod]
        public void CalculateTotalContractValueDifferenceOnFirstAndSecondOffers()
        {
            Contractor contractor = new Contractor("jan-1", "Company 1", "Eddie Murphy", "Eddie@gmail.com", 1, 2, 2, 3, 4);
            Route r = new Route(1, 2, 3, 5, 2);
            Offer o = new Offer("Jan-1", r, 250, contractor, 10);
            Contractor contractor2 = new Contractor("jan-2", "Company2", "Scarlet Johanson", "scarlet@gmail.com", 1, 2, 2, 1, 4);
       
            Offer o2 = new Offer("Jan-2", r, 300, contractor2, 10);
            r.ListOfOffers.Add(o);
            r.ListOfOffers.Add(o2);

            // contract value difference
            double routeValueDifference = r.ListOfOffers[1].ContractValue - r.ListOfOffers[0].ContractValue;

            //Assertions

            // If route has no offers will return 0
            Assert.AreEqual(r.GetTotalContractValueDifference(), 0);

            // If route has one offers will return 0
            r.AddToList(o);
            Assert.AreEqual(r.GetTotalContractValueDifference(), 0);

            // Will return true if difference is 50 between the 2 first offers in the list
            r.AddToList(o2);
            Assert.AreEqual(r.GetTotalContractValueDifference(), routeValueDifference);
        }

        [TestMethod]
        public void SortOffersByPriceAscending()
        {
          
            Contractor contractor = new Contractor("jan-1", "Company 1", "Eddie Murphy", "Eddie@gmail.com", 1, 2, 2, 3, 4);
            Route r = new Route(1, 2, 2,8,0);
            Offer o = new Offer("Jan-1", r, 250, contractor, 10);
            Contractor contractor2 = new Contractor("jan-1", "Company2", "Scarlet Johanson", "scarlet@gmail.com", 1, 2, 2, 1, 4);
            Offer o2 = new Offer("Jan-1", r, 300, contractor2, 10);
            Offer o3 = new Offer("Jan-1", r, 30, contractor, 10);

            r.AddToList(o);
            r.AddToList(o2);
            r.AddToList(o3);

            // Add to calculatewinner
            CalculateWinner.Instance.AddToRouteList(r);

            //assert that wrong route is first in unsorted list
            Assert.AreEqual(o.Price, CalculateWinner.Instance.GetRouteInIndex(0).ListOfOffers[0].Price);

            //assert that right route is first in sorted list
            CalculateWinner.Instance.SortOffersInRoutesByPriceAscending();
            Assert.AreEqual(o3.Price, CalculateWinner.Instance.GetRouteInIndex(0).ListOfOffers[0].Price);
        }

 

        public void SortRoutesByTotalContractValueDifference()
        {

            Contractor contractor = new Contractor("jan-1", "Company 1", "Eddie Murphy", "Eddie@gmail.com", 1, 2, 2, 3, 4);
            Contractor contractor2 = new Contractor("jan-1", "Company2", "Scarlet Johanson", "scarlet@gmail.com", 1, 2, 2, 1, 4);

            Route r = new Route(1, 2,8,6,0);
            Route r2 = new Route(2, 3,5,2,0);
            Route r3 = new Route(3, 3,6,5,7);

            // Offers for route one
            r.ListOfOffers.Add(new Offer("Jan-1", r, 100, contractor, 1));
            r.ListOfOffers.Add(new Offer("Jan-2", r, 150, contractor2, 0));
            // Offers for route two
            r2.ListOfOffers.Add(new Offer("Jan-3", r2, 200, contractor, 1));
            r2.ListOfOffers.Add(new Offer("Jan-4", r2, 280, contractor2, 1));
            // Offers for route three
            r3.ListOfOffers.Add(new Offer("Jan-5", r3, 150, contractor, 1));
            r3.ListOfOffers.Add(new Offer("Jan-6", r3, 210, contractor2, 1));

            // Add routes to list with routes
            CalculateWinner.Instance.AddToRouteList(r);
            CalculateWinner.Instance.AddToRouteList(r2);
            CalculateWinner.Instance.AddToRouteList(r3);

            // Calculate total contract value of 1st and 2nd offers in each route
            CalculateWinner.Instance.SortRoutesByTotalContractValueDifference();

            //assert that wrong route is first in unsorted list
            Assert.AreEqual(r.RouteNumber, CalculateWinner.Instance.GetRouteInIndex(0).ListOfOffers[0].Id);

            //assert that right route is first in sorted list
            CalculateWinner.Instance.SortOffersInRoutesByPriceAscending();
        
        }


        //Integration test
        [TestMethod]
        public void CanCalculateWinner()
        {
            CalculateWinner.Instance.CalculateWinners();
            CalculateWinner.Instance.GetWinners();
        }
    }
}
