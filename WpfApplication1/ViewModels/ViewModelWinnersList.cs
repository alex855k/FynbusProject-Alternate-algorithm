using System;
using FynbusProject;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using WPF_GUI.Helpers;
using WPF_GUI.Models;

namespace WPF_GUI.ViewModels
{
    public class ViewModelWinnersList
    {
        private CalculateWinner _cw = new CalculateWinner();
        private List<Route> _winningRoutes;

        private ICommand _updateCommand;
        private ObservableCollection<WinningOfferModel> _winningOffers;

        public ObservableCollection<WinningOfferModel> WinningOffers
        {
            get {
                if (_winningOffers == null)
                {
                    _winningOffers = new ObservableCollection<WinningOfferModel>();
                }
                return _winningOffers;
            }
        }

        public ICommand GetWinnersCommand
        {
            get
            {
                if (_updateCommand == null) _updateCommand = new RelayCommand<object>(GetWinners);
                return _updateCommand;
            }
        }

        public void GetWinners(object o)
        {
            _cw.CalculateWinners();
            _winningRoutes = _cw.GetWinners();
         
            foreach (Route route in _winningRoutes)
            {
                _winningOffers.Add(new WinningOfferModel(route.RouteNumber, route.WinningOffer.OfferContractor.CompanyName, route.WinningOffer.ContractValue));
            }
        }
    }
}
