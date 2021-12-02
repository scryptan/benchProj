using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BecnhProject.Pages
{
    public partial class TechChoose : Page, IInitializable
    {
        private readonly MainWindow _mainWindow;

        public TechChoose(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            var defaultCoef = new decimal(1.2);

            if (GetDecimalValue(QualitetCount.Text) != 0)
                _mainWindow.Coef *= defaultCoef;
            if (GetDecimalValue(InternalThread.Text) != 0)
                _mainWindow.Coef *= defaultCoef;
            if (GetDecimalValue(ExternalThread.Text) != 0)
                _mainWindow.Coef *= defaultCoef;

            _mainWindow.Coef *= GetDecimalValue(((ComboBoxItem) MinimalPlane.SelectedItem).Tag.ToString());
            _mainWindow.Coef *= GetDecimalValue(((ComboBoxItem) QualitetLower.SelectedItem).Tag.ToString());

            if (ThickWall.IsChecked ?? false) _mainWindow.Coef *= defaultCoef;
            if (LatheOperation.IsChecked ?? false) _mainWindow.Coef *= defaultCoef;
            if (Erosion.IsChecked ?? false) _mainWindow.Coef *= defaultCoef;
            if (Term.IsChecked ?? false) _mainWindow.Coef *= defaultCoef;

            _mainWindow.SetResultWindow();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var text = ((TextBox) sender).Text + e.Text;
            var pointCount = text.Count(x => x is '.');
            e.Handled = pointCount == 1 && text.Length == 1 || pointCount > 1 ||
                        !text.Replace(".", string.Empty).All(char.IsDigit);
        }

        private void NumberWithoutPointValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var text = ((TextBox) sender).Text + e.Text;
            e.Handled = !text.All(char.IsDigit);
        }

        public void Init()
        {
            decimal ld = 0;
            try
            {
                ld = _mainWindow.BlankLength / _mainWindow.BlankDiameter;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            var ldStr = $"{ld:0.000}";
            if (_mainWindow.BlankHeight == -1)
                ParametersText.Text = $@"L, мм={_mainWindow.BlankLength}
D, мм={_mainWindow.BlankDiameter}
M, кг={_mainWindow.BlueprintMass}
n, шт={_mainWindow.ModelCount}

Сотношение длины к диаметру:
L/D: {ldStr}";
            else
                ParametersText.Text = $@"L, мм={_mainWindow.BlankLength}
D, мм={_mainWindow.BlankDiameter}
M, кг={_mainWindow.BlueprintMass}
H, мм={_mainWindow.BlankHeight}
n, шт={_mainWindow.ModelCount}

Сотношение длины к диаметру:
L/D={ldStr}";

            foreach (var element in Holder.Children)
            {
                if (element is TextBlock textBlock && string.IsNullOrEmpty((string)textBlock.Tag))
                {
                    textBlock.Background = _mainWindow.blueGradientBrush;
                    textBlock.Foreground = new SolidColorBrush(Colors.Azure);
                }
            }
        }

        private decimal GetDecimalValue(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            text = text.Last() == '.' ? text.Replace(".", string.Empty).Trim() : text.Replace('.', ',').Trim();
            return decimal.Parse(text);
        }
    }
}