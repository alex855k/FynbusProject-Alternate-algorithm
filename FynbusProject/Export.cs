using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FynbusProject
{
    public class Export
    {

        private CalculateWinner cw = null;
        private List<Route> listOfWinners = new List<Route>();
        private int numberOfRows;
        public Export(CalculateWinner calculateWinner, int numRows)
        {
            cw = calculateWinner;
            numberOfRows = numRows;
        }



        public void ExportToPDF(string path)
        {
            listOfWinners = cw.GetWinners();

            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                PdfPTable table = new PdfPTable(numberOfRows);
                PreparePdfTable(table);

                document.Open();
                document.Add(table);
                document.Close();
                writer.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong saving the file");
            }


        }

        private void PreparePdfTable(PdfPTable table)
        {
            table.AddCell("Route number");
            table.AddCell("Company name");
            table.AddCell("Contact person");
            table.AddCell("Contract value");

            foreach (Route r in listOfWinners)
            {
                if (r.WinningOffer != null)
                {
                    table.AddCell(r.RouteNumber.ToString());
                    table.AddCell(r.WinningOffer.OfferContractor.CompanyName);
                    table.AddCell(r.WinningOffer.OfferContractor.PersonName);
                    table.AddCell(r.WinningOffer.ContractValue.ToString());
                }
            }
        }

        public void ExportToCSV(string path)
        {
            listOfWinners = cw.GetWinners();

            StringBuilder csvContent = PrepareCsvContent();

            try
            {
                File.WriteAllText(path, csvContent.ToString());
            }
            catch
            {
                throw new Exception("Something went wrong creating the file!");
            }

        }

        private StringBuilder PrepareCsvContent()
        {
            StringBuilder csvContent = new StringBuilder();

            csvContent.AppendLine("Route number,Company name,Contact person,Contract value");

            foreach (Route r in listOfWinners)
            {
                if (r.WinningOffer != null)
                {
                    string routeNr = r.RouteNumber.ToString();
                    string compName = r.WinningOffer.OfferContractor.CompanyName;
                    string personName = r.WinningOffer.OfferContractor.PersonName;
                    string contractValue = r.WinningOffer.ContractValue.ToString();

                    string newLine = string.Format("{0},{1},{2},{3}", routeNr, compName, personName, contractValue);

                    csvContent.AppendLine(newLine);
                }
            }

            return csvContent;
        }


    }
}
