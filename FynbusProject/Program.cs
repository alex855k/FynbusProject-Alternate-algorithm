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
            Console.WriteLine("Procurement Application");
            TestImportAndCalculateWinner();
            Console.ReadKey();
        }

        private void TestImportAndCalculateWinner()
        {
            string filepathRoutes = @"C:\Users\AlexanderH\Desktop\RouteNumbers.csv";
            string filepathOffers = @"C:\Users\AlexanderH\Desktop\offers2.csv";
            string filepathContractors = @"C:\Users\AlexanderH\Desktop\contractors2.csv";


            CSVImport.Instance.Import(filepathRoutes, fileType.ROUTES);
            CSVImport.Instance.Import(filepathContractors, fileType.CONTRACTORS);
            CSVImport.Instance.Import(filepathOffers, fileType.OFFERS);

            //CSVImport.Instance.PrintContractors();
            // Console.WriteLine("Count: " + CSVImport.Instance.ListOfRoutes.Count);
            //CSVImport.Instance.PrintRoutes();
            Console.WriteLine(CSVImport.Instance.ListOfRoutes[1].ListOfOffers.Count);

            Console.WriteLine(CSVImport.Instance.ListOfOffers.Count);
            CalculateWinner.Instance.CalculateWinners();
            CalculateWinner.Instance.CalculateWinners();
            List<Route> WinnersList = CalculateWinner.Instance.GetWinners();
            //Console.WriteLine(WinnersList.Count);

            foreach (Route r in WinnersList)
            {

                Console.WriteLine(r.RouteNumber + ": " + " Company name: " + r.WinningOffer.OfferContractor.CompanyName + ", Total Contract Value: " + r.WinningOffer.ContractValue + ",\nPrice: " + r.WinningOffer.Price);

            }
        }
    }
}
