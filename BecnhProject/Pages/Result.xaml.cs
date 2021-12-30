using System;
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
            res.AppendLine($"Общая масса всех заготовок, в кг: {Math.Ceiling(_mainWindow.BlankMass * _mainWindow.ModelCount)}");
            res.AppendLine($"Стоимость одной заготовки, в руб: {Math.Ceiling(_mainWindow.MaterialCost * _mainWindow.BlankMass)}");
            res.AppendLine($"Стоимость партии, в руб: {Math.Ceiling(_mainWindow.ResultSum)}");
            res.Append($"Стоимость одной детали, в руб: {Math.Ceiling(_mainWindow.Sum() * _mainWindow.Coef)}");
            ResultBlock.Text = res.ToString();
        }
    }
}