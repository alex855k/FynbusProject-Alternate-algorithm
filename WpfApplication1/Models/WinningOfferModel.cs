
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI.Models
{
    public class WinningOfferModel
    {
        public WinningOfferModel(int routeNumber, string companyName, double price, double totalContractValue)
        {
            RouteNumber = routeNumber;
            CompanyName = companyName;
            Price = price;
            TotalContractValue = totalContractValue;
        }
        public int RouteNumber{get;set;}
        public string CompanyName { get; set; }
        public double Price { get; set; }
        public double TotalContractValue { get; set; }
    }
}
