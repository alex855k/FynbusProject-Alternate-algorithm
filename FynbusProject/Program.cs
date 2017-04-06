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

            string filepathRoutes = @"C:\Users\AlexanderHvidt\Desktop\RouteNumbers.csv";
            string filepathOffers = @"C:\Users\AlexanderHvidt\Desktop\Tilbudsblanket_tilpasset skabelon_annonymiseret i csv_format (2).csv";
            string filepathContractors = @"C:\Users\AlexanderHvidt\Desktop\Stamoplysninger_tilpasset skabelon_annonymiseret i csv_format (2).csv";


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
                Console.WriteLine(r.RouteNumber + ": " + " Contractor name: " + r.WinningOffer.OfferContractor.CompanyName + ", Total Contract Value: " + r.WinningOffer.ContractValue + ",\nPrice: " + r.WinningOffer.Price);

            }
            Console.ReadKey();
        }
    }
}
