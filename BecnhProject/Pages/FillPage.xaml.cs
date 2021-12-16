using System.Windows;
using System.Windows.Controls;

namespace BecnhProject.Pages
{
    public partial class FillPage : Page
    {
        private readonly MainWindow _mainWindow;

        public FillPage(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.SetStartScreen();
        }
    }
}