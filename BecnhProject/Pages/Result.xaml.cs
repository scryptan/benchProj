using System.Globalization;
using System.Windows.Controls;

namespace BecnhProject.Pages
{
    public partial class Result : Page, IInitializable
    {
        private readonly MainWindow _mainWindow;

        public Result(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        public void Init()
        {
            ResultBlock.Text = ((long)_mainWindow.ResultSum).ToString(CultureInfo.InvariantCulture);
        }
    }
}