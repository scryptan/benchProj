﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var text = ((TextBox) sender).Text + e.Text;
            var pointCount = text.Count(x => x is '.');
            e.Handled = pointCount == 1 && text.Length == 1 || pointCount > 1 ||
                        !text.Replace(".", string.Empty).All(char.IsDigit);
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

            if (_mainWindow.BlankHeight == -1)
                ParametersText.Text = $@"L, мм={_mainWindow.BlankLength}
D, мм={_mainWindow.BlankDiameter}
M, кг={_mainWindow.BlueprintMass}
n, шт={_mainWindow.ModelCount}

Сотношение длины к диаметру:
L/D: {ld}";
            else
                ParametersText.Text = $@"L, мм={_mainWindow.BlankLength}
D, мм={_mainWindow.BlankDiameter}
M, кг={_mainWindow.BlueprintMass}
H, мм={_mainWindow.BlankHeight}
n, шт={_mainWindow.ModelCount}

Сотношение длины к диаметру:
L/D={ld}";
        }
    }
}