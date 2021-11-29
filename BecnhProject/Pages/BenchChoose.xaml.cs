using System.Windows;
using System.Windows.Controls;
using BecnhProject.Models;

namespace BecnhProject.Pages
{
    public partial class BenchChoose : Page
    {
        private readonly MainWindow _mainWindow;

        public BenchChoose(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            
            LatheUpper.Content = BenchModel.Ctx310;
            LatheDown.Content = BenchModel.Ctx510;
            MillingUpper.Content = BenchModel.Dmu105;
            MillingDown.Content = BenchModel.Dmu635V;
        }

        private void ButtonPressed(object sender, RoutedEventArgs e)
        {
            _mainWindow.BenchModel = (BenchModel)((Button) sender).Content;
            _mainWindow.BenchButton.Content = _mainWindow.BenchModel;
            _mainWindow.SetMaterialWindow();
        }
    }
}