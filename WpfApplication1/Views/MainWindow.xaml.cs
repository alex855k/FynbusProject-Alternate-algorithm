using System.Windows;
using FynbusProject;
using Microsoft.Win32;
using System;
using WPF_GUI.Models;
using WPF_GUI.ViewModels;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {

            textBox_BasicData.Text = string.Empty;
            textBox_OfferData.Text = string.Empty;
            textBox_Routes.Text = string.Empty;
            DisableButtonsAfterClear();
            bool dataCleared = CSVImport.Instance.ClearData();

            if (dataCleared)
            {
                MessageBox.Show("Data and interface cleared sucessfuly!");
            }
            else
            {
                MessageBox.Show("Oops! Something went wrong clearing the data, please try again");
            }
        }

        private void button_ChooseContractorData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.AddExtension = true;
            ofd.ShowDialog();
            textBox_BasicData.Text = ofd.FileName;
        }

        private void button_ChooseOfferData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.AddExtension = true;
            ofd.ShowDialog();
            textBox_OfferData.Text = ofd.FileName;
        }

        private void button_ChooseRoutes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.AddExtension = true;
            ofd.ShowDialog();
            textBox_Routes.Text = ofd.FileName;
        }

        private void button_Import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CSVImport.Instance.Import(textBox_Routes.Text, fileType.ROUTES);
                CSVImport.Instance.Import(textBox_BasicData.Text, fileType.CONTRACTORS);
                CSVImport.Instance.Import(textBox_OfferData.Text, fileType.OFFERS);
                EnableButtonsAfterImport();
                MessageBox.Show("Data imported sucessfuly!");
            }
            catch
            {
                MessageBox.Show("Something went wrong with the import, please verify the files and try again!");
            }
        }

        private void EnableButtonsAfterImport()
        {
            button_CalculateWinners.IsEnabled = true;
            button_Clear.IsEnabled = true;
            button_ExportCsv.IsEnabled = true;
            button_ExportPdf.IsEnabled = true;
        }

        private void DisableButtonsAfterClear()
        {
            button_CalculateWinners.IsEnabled = false;
            button_Clear.IsEnabled = false;
            button_ExportCsv.IsEnabled = false;
            button_ExportPdf.IsEnabled = false;
        }
        private void button_ExportPdf_Click(object sender, RoutedEventArgs e)
        {
            CalculateWinner cw = new CalculateWinner();
            cw.GetWinners();

            Export exp = new Export(cw, 4);
            try
            {
                exp.ExportToPDF(GetPlaceToSave(".pdf"));
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

        private void button_ExportCsv_Click(object sender, RoutedEventArgs e)
        {
            CalculateWinner cw = new CalculateWinner();
            cw.GetWinners();

            Export exp = new Export(cw, 4);
            try
            {
                exp.ExportToCSV(GetPlaceToSave(".csv"));
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

        private string GetPlaceToSave(string extension)
        {
            string placeToSave = null;
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.DefaultExt = extension;
            if (saveFileDialog.ShowDialog() == true)
                placeToSave = saveFileDialog.FileName;
            else
                throw new Exception("User canceled save");

            return placeToSave;
        }
    }
}
