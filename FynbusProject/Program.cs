using System;

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
            string filepathRoutes = @"C:\fynbus\RouteNumbers.csv";
            string filepathOffers = @"C:\fynbus\Tilbud_FakeData.csv";
            string filepathContractors = @"C:\fynbus\Stamoplysninger_FakeData.csv";


            CSVImport.Instance.Import(filepathRoutes, fileType.ROUTES);
            CSVImport.Instance.Import(filepathContractors, fileType.CONTRACTORS);
            CSVImport.Instance.Import(filepathOffers, fileType.OFFERS);

            CSVImport.Instance.PrintContractors();
            CSVImport.Instance.PrintRoutes();
            Route route = CSVImport.Instance.ListOfRoutes[1];

            CalculateWinner cw = new CalculateWinner();
            cw.GetWinners();
            Console.WriteLine("Finished");

           

            cw.PrintWinners();

            Console.ReadKey();
        }
    }
}
