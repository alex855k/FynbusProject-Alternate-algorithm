
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    public class WinningOfferModel
    {
        public WinningOfferModel(int routeNumber, string companyName, double totalContractValue)
        {
            RouteNumber = routeNumber;
            CompanyName = companyName;
            TotalContractValue = totalContractValue;
        }
        public int RouteNumber{get;set;}
        public string CompanyName { get; set; }
        public double TotalContractValue { get; set; }
    }
}
