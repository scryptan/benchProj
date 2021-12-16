using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BecnhProject.Extensions;
using BecnhProject.Models;

namespace BecnhProject.Pages
{
    public partial class MaterialChoose : Page, IInitializable
    {
        private readonly MainWindow _mainWindow;

        public MaterialChoose(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void MaterialButtonClicked(object sender, RoutedEventArgs e)
        {
            CurrentButtonsPanel.Children.Clear();
            var matType = Enum.Parse<MaterialType>(((Button) sender).Name.Replace("Button", ""));
            _mainWindow.MaterialType = matType;

            switch (matType)
            {
                case MaterialType.Steel:
                    var nonAlloy = new Button
                    {
                        Name = $"{MaterialType.NonAlloySteel}Button",
                        Content = MaterialType.NonAlloySteel.ToDescriptionString(),
                        Background = _mainWindow.blueGradientBrush,
                        Foreground = new SolidColorBrush(Colors.Azure),
                        FontSize = 42
                    };
                    CurrentButtonsPanel.Children.Add(nonAlloy);
                    Grid.SetRow(nonAlloy, 0);

                    var alloy = new Button
                    {
                        Name = $"{MaterialType.AlloySteel}Button",
                        Content = MaterialType.AlloySteel.ToDescriptionString(),
                        Background = _mainWindow.blueGradientBrush,
                        Foreground = new SolidColorBrush(Colors.Azure),
                        FontSize = 42
                    };
                    CurrentButtonsPanel.Children.Add(alloy);
                    Grid.SetRow(nonAlloy, 1);

                    var highAlloy = new Button
                    {
                        Name = $"{MaterialType.HighAlloySteel}Button",
                        Content = MaterialType.HighAlloySteel.ToDescriptionString(),
                        Background = _mainWindow.blueGradientBrush,
                        Foreground = new SolidColorBrush(Colors.Azure),
                        FontSize = 42
                    };
                    CurrentButtonsPanel.Children.Add(highAlloy);
                    Grid.SetRow(highAlloy, 2);
                    break;
                case MaterialType.StainlessSteel:
                    var bar = new Button
                    {
                        Name = $"{MaterialType.StainlessSteelBar}Button",
                        Content = MaterialType.StainlessSteelBar.ToDescriptionString(),
                        Background = _mainWindow.blueGradientBrush,
                        Foreground = new SolidColorBrush(Colors.Azure),
                        FontSize = 42
                    };
                    CurrentButtonsPanel.Children.Add(bar);
                    Grid.SetRow(bar, 0);

                    var cast = new Button
                    {
                        Name = $"{MaterialType.StainlessSteelCast}Button",
                        Content = MaterialType.StainlessSteelCast.ToDescriptionString(),
                        Background = _mainWindow.blueGradientBrush,
                        Foreground = new SolidColorBrush(Colors.Azure),
                        FontSize = 42
                    };
                    CurrentButtonsPanel.Children.Add(cast);
                    Grid.SetRow(cast, 1);
                    break;
                case MaterialType.HeatResistance:
                    var titan = new Button
                    {
                        Name = $"{MaterialType.HeatResistanceTitan}Button",
                        Content = MaterialType.HeatResistanceTitan.ToDescriptionString(),
                        Background = _mainWindow.blueGradientBrush,
                        Foreground = new SolidColorBrush(Colors.Azure),
                        FontSize = 42
                    };
                    CurrentButtonsPanel.Children.Add(titan);
                    Grid.SetRow(titan, 0);

                    var heatChecked = new Button
                    {
                        Name = $"{MaterialType.HeatResistanceChecked}Button",
                        Content = MaterialType.HeatResistanceChecked.ToDescriptionString(),
                        Background = _mainWindow.blueGradientBrush,
                        Foreground = new SolidColorBrush(Colors.Azure),
                        FontSize = 42
                    };
                    CurrentButtonsPanel.Children.Add(heatChecked);
                    Grid.SetRow(heatChecked, 1);
                    break;
                default:
                    _mainWindow.SetBlankWindow();
                    break;
            }

            foreach (Button element in CurrentButtonsPanel.Children)
                element.Click += MaterialButtonClicked;
        }

        public void Init()
        {
            foreach (Button element in ButtonsPanel.Children)
            {
                element.Content = Enum.Parse<MaterialType>(element.Name.Replace("Button", "")).ToDescriptionString();

                element.Background = _mainWindow.blueGradientBrush;
                element.Foreground = new SolidColorBrush(Colors.Azure);
                element.FontSize = 42;
            }
        }
    }
}