using System.Text;
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
            var res = new StringBuilder();
            res.AppendLine($"Общая масса всех заготовок, в кг: {_mainWindow.BlankMass * _mainWindow.ModelCount}");
            res.AppendLine($"Стоимость одной заготовки, в руб: {_mainWindow.MaterialCost * _mainWindow.BlankMass}");
            res.AppendLine($"Стоимость партии, в руб: {_mainWindow.ResultSum}");
            res.Append($"Стоимость одной детали, в руб: {_mainWindow.Sum() * _mainWindow.Coef}");
            ResultBlock.Text = res.ToString();
        }
    }
}