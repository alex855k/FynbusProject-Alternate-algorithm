using System;
using System.Collections.Generic;

namespace FynbusProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            new FynbusProject.Program().Run();
        }

        private void Run()
        {
     
            string filepathRoutes = @"C:\Users\AlexanderH\Desktop\RouteNumbers.csv";
            string filepathOffers = @"C:\Users\AlexanderH\Desktop\Tilbud_FakeData.csv";
            string filepathContractors = @"C:\Users\AlexanderH\Desktop\Stamoplysninger_FakeData.csv";


            CSVImport.Instance.Import(filepathRoutes, fileType.ROUTES);
            CSVImport.Instance.Import(filepathContractors, fileType.CONTRACTORS);
            CSVImport.Instance.Import(filepathOffers, fileType.OFFERS);

            CSVImport.Instance.PrintContractors();
            CSVImport.Instance.PrintRoutes();
            Route route = CSVImport.Instance.ListOfRoutes[1];

            CalculateWinner cw = new CalculateWinner();
            
            List<Route> WinnersList = cw.GetWinners();

            foreach (Route r in WinnersList)
            {
                Console.WriteLine(r.RouteNumber + ": " + " Contractor name: " + r.WinningOffer.OfferContractor.CompanyName+ ", Total Contract Value: " + r.WinningOffer.ContractValue + ",\nPrice: " + r.WinningOffer.Price);
 
            }
            Console.ReadKey();
        }
    }
}
