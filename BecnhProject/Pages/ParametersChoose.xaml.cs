using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BecnhProject.Models;

namespace BecnhProject.Pages
{
    public partial class ParametersChoose : Page, IInitializable
    {
        private readonly MainWindow _mainWindow;

        public ParametersChoose(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var text = ((TextBox) sender).Text + e.Text;
            var pointCount = text.Count(x => x is '.');
            e.Handled = pointCount == 1 && text.Length == 1 || pointCount > 1 ||
                        !text.Replace(".", string.Empty).All(char.IsDigit);
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _mainWindow.BlankLength = GetDecimalValue(LengthBox.Text);
                _mainWindow.BlankHeight = GetDecimalValue(HeightBox.Text);
                if (HeightBox.Visibility == Visibility.Hidden)
                    _mainWindow.BlankHeight = -1;
                _mainWindow.BlankDiameter = GetDecimalValue(DiameterBox.Text);
                _mainWindow.BlueprintMass = GetDecimalValue(MassBox.Text);
                _mainWindow.ModelCount = GetDecimalValue(CountBox.Text);
                _mainWindow.IsFree = IsFree.IsChecked ?? false;
                _mainWindow.MaterialCost = _mainWindow.IsFree ? 0 : GetDecimalValue(CostBox.Text);
                _mainWindow.HoleDiameter = GetDecimalValue(HoleDiameterBox.Text);
                _mainWindow.HoleLength = GetDecimalValue(HoleLengthBox.Text);
                if (HeightBox.Visibility != Visibility.Visible)
                {
                    _mainWindow.BlankDiameter = GetDecimalValue(DiameterСomboBox.Text);
                    if (_mainWindow.BlankDiameter < 30)
                        _mainWindow.Coef *= (40 / _mainWindow.BlankDiameter);

                    if (_mainWindow.BlankDiameter > 50)
                        _mainWindow.Coef *= (decimal) 1.5;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            _mainWindow.SetTechWindow();
        }

        private decimal GetDecimalValue(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            text = text.Last() == '.' ? text.Replace(".", string.Empty).Trim() : text.Replace('.', ',').Trim();
            return decimal.Parse(text);
        }

        public void Init()
        {
            HeightBox.Visibility =
                _mainWindow.BlankType == BlankType.RollMetal ? Visibility.Hidden : Visibility.Visible;
            HeightBlock.Visibility =
                _mainWindow.BlankType == BlankType.RollMetal ? Visibility.Hidden : Visibility.Visible;

            if (HeightBox.Visibility == Visibility.Visible)
            {
                DiameterBlock.Text = "Ширина заготовки, мм = ";
                DiameterBox.Visibility = Visibility.Visible;
                DiameterСomboBox.Visibility = Visibility.Hidden;
            }
            else
            {
                DiameterBlock.Text = "Диаметр заготовки, мм = ";
                DiameterBox.Visibility = Visibility.Hidden;
                DiameterСomboBox.Visibility = Visibility.Visible;
            }
        }
    }
}