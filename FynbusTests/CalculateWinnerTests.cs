using FynbusProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FynbusTests
{
    [TestClass]
    public class CalculateWinnerTests
    {

        private CalculateWinner cw;
        private Route testRoute;

        [TestInitialize]
        public void Initialize()
        {

        }
        //Unit Tests

        //[TestMethod]
        //public void CanGetDifferenceOnFirstAndSecondOffers()
        //{
        //    Contractor contractor = new Contractor("jan-1", "dasdad", "Thomas Hvidt", "sadad@gadas.com", 1, 2, 2, 3, 4);
        //    Route r = new Route(1, 1);
        //    Offer o = new Offer("Jan-1", r, 250, contractor, 10);
        //    Contractor contractor2 = new Contractor("jan-1", "dasdad", "Thomas Hvidt", "sadad@gadas.com", 1, 2, 2, 1, 4);
        //    Offer o2 = new Offer("Jan-1", r, 300, contractor, 10);
        //    r.AddToList(o);
        //    r.AddToList(o2);
        //    Assert.AreEqual(r.GetTotalContractValueDifference(), 50);
        //}



        [TestMethod]
        public void CanSortRouteByPriceAscending()
        {
            CalculateWinner calculateWinner = new CalculateWinner();
            Contractor contractor = new Contractor("jan-1", "Datguy", "Firstguy", "sadad@gadas.com", 1, 2, 2, 3, 4);
            Route r = new Route(1, 2);
            Offer o = new Offer("Jan-1", r, 250, contractor, 10);
            Contractor contractor2 = new Contractor("jan-1", "Datotherguy", "Otherguy", "otherguy@live.com", 1, 2, 2, 1, 4);
            Offer o2 = new Offer("Jan-1", r, 300, contractor2, 10);
            Offer o3 = new Offer("Jan-1", r, 30, contractor, 10);

            r.AddToList(o);
            r.AddToList(o2);
            r.AddToList(o3);

            // add to calculatewinner
            calculateWinner.AddToRouteList(r);

            //assert that wrong route is first in unsorted list
            Assert.AreEqual(o.Price, calculateWinner.GetRouteInIndex(0).ListOfOffers[0].Price);

            //assert that right route is first in sorted list
            calculateWinner.SortOffersInRoutesByPriceAscending();
            Assert.AreEqual(o3.Price, calculateWinner.GetRouteInIndex(0).ListOfOffers[0].Price);
        }

        //[TestMethod]
        //public void CanSortRouteByHighestDifferenceAscending2()
        //{
        //    CalculateWinner calculateWinner = new CalculateWinner();
        //    Contractor contractor = new Contractor("jan-1", "Datguy", "Firstguy", "sadad@gadas.com", 1, 2, 2, 3, 4);
        //    Route r = new Route(1, 2);
        //    Offer o = new Offer("Jan-1", r, 250, contractor, 10);
        //    Contractor contractor2 = new Contractor("jan-1", "Datotherguy", "Otherguy", "otherguy@live.com", 1, 2, 2, 1, 4);
        //    Offer o2 = new Offer("Jan-1", r, 300, contractor2, 10);
        //    Offer o3 = new Offer("Jan-1", r, 30, contractor, 10);
        //    Offer o4 = new Offer("Jan-1", r, 270, contractor2, 10);
        //    r.AddToList(o);
        //    r.AddToList(o2);
        //    Route r2 = new Route(2, 2);
        //    r2.AddToList(o3);
        //    r2.AddToList(o4);
        //    // add to calculatewinner
        //    calculateWinner.AddToRouteList(r);
        //    calculateWinner.AddToRouteList(r2);

        //    calculateWinner.SortOffersInRoutesByPriceAscending();
        //    //assert that wrong route is first in unsorted list
        //    Assert.AreEqual(r.RouteNumber, calculateWinner.GetRouteInIndex(0).RouteNumber);

        //    //assert that right route is first in sorted list
        //    calculateWinner.SortRoutesByTotalContractValueDifference();
        //    Assert.AreEqual(r2.RouteNumber, calculateWinner.GetRouteInIndex(0).RouteNumber);
        //}

        public void CanSorByPriorityOnSamePrice()
        {
            CalculateWinner calculateWinner = new CalculateWinner();

            Contractor contractor = new Contractor("jan-1", "Datguy", "Firstguy", "sadad@gadas.com", 1, 2, 2, 3, 4);
            Contractor contractor2 = new Contractor("jan-1", "Datotherguy", "Otherguy", "otherguy@live.com", 1, 2, 2, 1, 4);


            Route r = new Route(1, 2);

            Offer o = new Offer("Jan-1", r, 250, contractor, 1);
            Offer o2 = new Offer("Jan-2", r, 250, contractor2, 0);
            Offer o3 = new Offer("Jan-3", r, 300, contractor, 3);
            Offer o4 = new Offer("Jan-4", r, 300, contractor2, 0);

            r.AddToList(o);
            r.AddToList(o2);
            r.AddToList(o3);
            r.AddToList(o4);

            // add to calculatewinner
            calculateWinner.AddToRouteList(r);

            calculateWinner.SortOffersInRoutesByPriceAscending();
            //assert that wrong route is first in unsorted list
            Assert.AreEqual(o.Id, calculateWinner.GetRouteInIndex(0).ListOfOffers[0].Id);

            //assert that right route is first in sorted list
            calculateWinner.SortOffersInRoutesByPriceAscending();
            Assert.AreEqual(o2.Id, calculateWinner.GetRouteInIndex(0).ListOfOffers[0].Id);
            Assert.AreEqual(o.Id, calculateWinner.GetRouteInIndex(0).ListOfOffers[1].Id);

            Assert.AreEqual(o4.Id, calculateWinner.GetRouteInIndex(0).ListOfOffers[2].Id);
            Assert.AreEqual(o3.Id, calculateWinner.GetRouteInIndex(0).ListOfOffers[3].Id);
        }


        //Integration test
        [TestMethod]
        public void CanCalculateWinner()
        {
            CalculateWinner calculateWinner = new CalculateWinner();
        }


        [TestMethod]
        public void CanGetAvaliableHoursForRoute()
        {
           AvaliableHours av = AvaliableHours.Instance;
           RouteAvaliableHours routeAvHour = new RouteAvaliableHours();


            Assert.AreEqual(4698, av.GetAvaliableHours(1));
            Assert.AreEqual(7742, av.GetAvaliableHours(2));
        }

        [TestMethod]
        public void CanGetTotalContractValue()
        {
            Contractor contractor = new Contractor("jan-1", "dasdad", "Thomas Hvidt", "sadad@gadas.com", 1, 2, 2, 3, 4);
            Route r = new Route(1, 1);
            Offer o = new Offer("Jan-1", r, 250, contractor, 10);
            AvaliableHours av = AvaliableHours.Instance;
            Assert.AreEqual(4698*o.Price, o.ContractValue);
        }
        
    }
}
