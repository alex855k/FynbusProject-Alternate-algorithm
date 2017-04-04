using FynbusProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FynbusTests
{
    //[TestClass]
    //public class ImportTests
    //{
    //    [TestMethod]
    //    public void CanImportRouteFile()
    //    {
    //        string routeFilePath = @"C:\Users\Kast\Desktop\Fynbus\Flexcel_Fynbus\Flex-Sortering 1.02\RouteNumbers.csv";
    //        bool routeFile = CSVImport.Instance.Import(routeFilePath, fileType.ROUTES);

    //        Assert.IsTrue(routeFile);
    //    }

    //    [TestMethod]
    //    public void CannotImportWrongDataRouteFile()
    //    {
    //        string routeFilePath_wrong = @"C:\Users\Kast\Desktop\Fynbus\Flexcel_Fynbus\Flex-Sortering 1.02\RouteNumbers.csv";
    //        bool wrongDataformat = CSVImport.Instance.Import(routeFilePath_wrong, fileType.CONTRACTORS);

    //        Assert.IsFalse(wrongDataformat);
    //    }

    //    [TestMethod]
    //    public void CanImportContractorFile()
    //    {
    //        string contractorFilepath = @"C:\Users\Kast\Desktop\Fynbus\Flexcel_Fynbus\FakeData_Tests\Test med 3 bud til samme rute\Stamoplysninger_FakeData.csv";
    //        bool contractorFile = CSVImport.Instance.Import(contractorFilepath, fileType.CONTRACTORS);

    //        Assert.IsTrue(contractorFile);
    //    }

    //    [TestMethod]
    //    public void CannotImportWrongContractorFile()
    //    {
    //        string contractorFilePath_wrong = @"C:\Users\Kast\Desktop\Fynbus\Flexcel_Fynbus\FakeData_Tests\Test med 3 bud til samme rute\Tilbud_FakeData.csv";
    //        bool wrongDataformat = CSVImport.Instance.Import(contractorFilePath_wrong, fileType.CONTRACTORS);

    //        Assert.IsFalse(wrongDataformat);
    //    }
    //    [TestMethod]
    //    public void CanImportOfferFile()
    //    {

    //        string offerFilepath = @"C:\Users\Kast\Desktop\Fynbus\Flexcel_Fynbus\FakeData_Tests\Test med 3 bud til samme rute\Tilbud_FakeData.csv";
    //        bool offerFile = CSVImport.Instance.Import(offerFilepath, fileType.OFFERS);

    //        Assert.IsTrue(offerFile);
    //    }

    //    [TestMethod]
    //    public void CannotImportWrongOfferFile()
    //    {
    //        string offerFilepath_wrong = @"C:\Users\Kast\Desktop\Fynbus\Flexcel_Fynbus\FakeData_Tests\Test med 3 bud til samme rute\Tilbud_FakeData.csv";
    //        bool wrongDataformat = CSVImport.Instance.Import(offerFilepath_wrong, fileType.CONTRACTORS);

    //        Assert.IsFalse(wrongDataformat);
    //    }

    //    [TestMethod]
    //    public void CanAccessContractorInformation()
    //    {
    //        Route route = CSVImport.Instance.ListOfRoutes[1];
    //        Assert.AreEqual(3, route.ListOfOffers[0].OfferContractor.TypeV2);
    //    }

    //}
}
