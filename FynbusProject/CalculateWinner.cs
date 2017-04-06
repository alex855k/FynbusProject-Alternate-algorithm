using System;
using System.Collections.Generic;
using System.Linq;

namespace FynbusProject
{
    public class CalculateWinner
    {
        private List<Route> _routesList;
        private List<Route> _resolvedRoutesList = new List<Route>();

        public CalculateWinner()
        {
            // Adding route objects from the import class in the RoutesList
            _routesList = new List<Route>();

            foreach (Route r in CSVImport.Instance.ListOfRoutes.Values)
            {
                AddToRouteList(r);
            }
        }

        public void SortOffersInRoutesByPriceAscending()
        {
            foreach (Route r in _routesList)
            {
                r.SortListOfOffers();
            }
        }

        public void AddToRouteList(Route r)
        {
            _routesList.Add(r);
        }

        public Route GetRouteInIndex(int index)
        {
            //Getting a route object from an index in the list
            return _routesList[index];
        }

        public void SortRoutesByTotalContractValueDifference()
        {
            List<Route> sortedRoutesList = _routesList.FindAll(r => r.HasWinner() == false).OrderByDescending(r => r.GetTotalContractValueDifference()).ThenBy(r => r.RoutePriority).ToList();
            //Updating the RoutesList with sorted values
            _routesList = sortedRoutesList;
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
                Route currentRoute = _routesList[routeIndex];

                if (currentRoute.FirstOfferHasVehicleLeft() || currentRoute.ListOfOffers.Count <= 0)
                {
                    SetWinnerForRoute(currentRoute);
                    _resolvedRoutesList.Add(currentRoute);

                }
                else
                {
                    Console.WriteLine("No vehicles left " + currentRoute.ListOfOffers[0].OfferContractor + " for route: #" + currentRoute.RouteNumber);
                    SortOffersInRoutesByPriceAscending();
                    SortRoutesByTotalContractValueDifference();
                    routeIndex = 0;
                }

                if (routeIndex == (_routesList.Count() - 1))
                {
                    hasFoundAllWinners = true;
                }
                else
                {
                    routeIndex++;
                }
            }

            return _resolvedRoutesList.OrderBy(r => r.RouteNumber).ToList();
        }

        private void SetWinnerForRoute(Route r)
        {
            r.SetWinningOffer();
            if (r.ListOfOffers.Count > 0)
            {
                r.WinningOffer.OfferContractor.DecrementAmountOfVehicleOfType(r.VehicleType);
            }
        }


    }
}
