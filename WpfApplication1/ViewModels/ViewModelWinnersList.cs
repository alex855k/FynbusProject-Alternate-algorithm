using FynbusProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    listOfWinningOffers.Add(new WinningOfferModel(route.RouteNumber, route.CompanyName, route.WinningOffer.ContractValue));
                }
                return listOfWinningOffers;
            }

        }


    }
}
