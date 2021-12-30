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
            
            if (_mainWindow.BlankLength / _mainWindow.HoleLength < 2)
                _mainWindow.Coef *= defaultCoef;
            
            switch (_mainWindow.HoleLength / _mainWindow.HoleDiameter)
            {
                case 1/(decimal)2:
                    _mainWindow.Coef *= 1;
                    break;
                case 1/(decimal)1:
                    _mainWindow.Coef *= 1;
                    break;
                case 1/(decimal)3:
                    _mainWindow.Coef *= 1;
                    break;
            }

            if (MinimalPlane.SelectedItem != null)
                _mainWindow.Coef *= GetDecimalValue(((ComboBoxItem) MinimalPlane.SelectedItem).Tag.ToString());
            if (QualitetLower.SelectedItem != null)
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
            decimal ldHole = 0;
            try
            {
                ld = _mainWindow.BlankLength / _mainWindow.BlankDiameter;
                ldHole = _mainWindow.HoleLength / _mainWindow.HoleDiameter;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            var ldStr = $"{ld:0.000}";
            var ldHoleStr = $"{ldHole:0.000}";
            if (_mainWindow.BlankHeight == -1)
                ParametersText.Text = $@"Длина детали, мм={_mainWindow.BlankLength}
Диаметр детали, мм={_mainWindow.BlankDiameter}
Масса заготовки, кг={_mainWindow.BlankMass}
Количество детали в партии, шт={_mainWindow.ModelCount}

Сотношение длины детали к диаметру детали:
L/D: {ldStr}
Сотношение длины отверстия к диаметру отверстия:
L/D: {ldHoleStr}";
            else
                ParametersText.Text = $@"Длина детали, мм={_mainWindow.BlankLength}
Диаметр детали, мм={_mainWindow.BlankDiameter}
Масса заготовки, кг={_mainWindow.BlankMass}
Высота детали, мм={_mainWindow.BlankHeight}
Количество детали в партии, шт={_mainWindow.ModelCount}

Сотношение длины детали к диаметру детали:
L/D={ldStr}
Сотношение длины отверстия к диаметру отверстия:
L/D={ldHoleStr}";

            foreach (var element in Holder.Children)
            {
                if (element is TextBlock textBlock && string.IsNullOrEmpty((string) textBlock.Tag))
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