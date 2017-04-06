using FynbusProject;
using System.Collections.Generic;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class ViewModelWinnersList
    {
        CalculateWinner cw = new CalculateWinner();
        List<WinningOfferModel> listOfWinningOffers = new List<WinningOfferModel>();

        public List<WinningOfferModel> WinningRoute
        {
            get
            {
                foreach (Route route in cw.GetWinners())
                {
                    listOfWinningOffers.Add(new WinningOfferModel(route.RouteNumber, route.WinningOffer.OfferContractor.CompanyName, route.WinningOffer.ContractValue));
                }
                return listOfWinningOffers;
            }

        }
    }
}
