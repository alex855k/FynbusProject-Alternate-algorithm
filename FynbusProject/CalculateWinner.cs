using System;
using System.Collections.Generic;
using System.Linq;

namespace FynbusProject
{
    public class CalculateWinner
    {
        private List<Route> RoutesList;
        private List<Route> ResolvedRoutesList;

        public CalculateWinner()
        {
            RoutesList = new List<Route>();
            // Adding route objects from the import class in the RoutesList
            foreach (Route r in CSVImport.Instance.ListOfRoutes.Values)
            {
                AddToRouteList(r);
            }
        }

        public void SortOffersInRoutesByPriceAscending()
        {
            foreach (Route r in RoutesList)
            {
                r.SortListOfOffers();
            }
        }

        public void AddToRouteList(Route r)
        {
            RoutesList.Add(r);
        }

        public Route GetRouteInIndex(int index)
        {
            //Getting a route object from an index in the list
            return RoutesList[index];
        }

        public void SortRoutesByTotalContractValueDifference()
        {
            List<Route> sortedRoutesList = RoutesList.FindAll(r => r.HasWinner() == false).OrderByDescending(r => r.GetTotalContractValueDifference()).ThenBy(r => r.RoutePriority).ToList();
            //Updating the RoutesList with sorted values
            RoutesList = sortedRoutesList;
        }

        // Main method called for calculating winners
        public List<Route> GetWinners()
        {
            // Sorts the collection of offers on each route by price ascending
            SortOffersInRoutesByPriceAscending();
            // sort routes by the price difference
            SortRoutesByTotalContractValueDifference();
            // Loops over the list using this counter, resets if it finds a route with invalid offers
            int routeIndex = 0;
            bool hasFoundAllWinners = false;
            while (!hasFoundAllWinners)
            {
                Route currentRoute = RoutesList[routeIndex];
               
                if (currentRoute.FirstOfferHasVehicleLeft())
                {
                    SetWinnerForRoute(currentRoute);
                    ResolvedRoutesList.Add(currentRoute);
                }
                else
                {
                    SortOffersInRoutesByPriceAscending();
                    SortRoutesByTotalContractValueDifference();
                    routeIndex = 0;
                }
              
                if (routeIndex == (RoutesList.Count() - 1))
                {
                    hasFoundAllWinners = true;
                }
                else
                {
                    routeIndex++;
                }
            }
            return ResolvedRoutesList;
        }

        private void SetWinnerForRoute(Route r)
        {
            if (r.ListOfOffers.Count > 0)
            {
                Console.Write("\n Found winner for route #" + r.RouteNumber + "\n");
                r.SetWinningOffer();
                r.WinningOffer.OfferContractor.DecrementAmountOfVehicleOfType(r.VehicleType);
            }
        }


    }
}
