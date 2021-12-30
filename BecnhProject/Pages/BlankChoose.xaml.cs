using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BecnhProject.Extensions;
using BecnhProject.Models;

namespace BecnhProject.Pages
{
    public partial class BlankChoose : Page, IInitializable
    {
        private readonly MainWindow _mainWindow;

        public BlankChoose(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            var blankType = Enum.Parse<BlankType>(((Button) sender).Name.Replace("Button", ""));
            _mainWindow.BlankType = blankType;
            _mainWindow.SetParametersWindow();
        }

        public void Init()
        {
            var casting = new Button
            {
                Name = $"{BlankType.Casting}Button",
                Content = BlankType.Casting.ToDescriptionString(),
                Background = _mainWindow.blueGradientBrush,
                Foreground = new SolidColorBrush(Colors.Azure),
                FontSize = 52
            };
            MainGrid.Children.Add(casting);
            var list = new Button
            {
                Name = $"{BlankType.List}Button",
                Content = BlankType.List.ToDescriptionString(),
                Background = _mainWindow.blueGradientBrush,
                Foreground = new SolidColorBrush(Colors.Azure),
                FontSize = 52
            };
            MainGrid.Children.Add(list);
            var stamping = new Button
            {
                Name = $"{BlankType.Stamping}Button",
                Content = BlankType.Stamping.ToDescriptionString(),
                Background = _mainWindow.blueGradientBrush,
                Foreground = new SolidColorBrush(Colors.Azure),
                FontSize = 52
            };
            MainGrid.Children.Add(stamping);
            var rollMetal = new Button
            {
                Name = $"{BlankType.RollMetal}Button",
                Content = BlankType.RollMetal.ToDescriptionString(),
                Background = _mainWindow.greenGradientBrush,
                Foreground = new SolidColorBrush(Colors.Azure),
                FontSize = 52
            };
            MainGrid.Children.Add(rollMetal);
            Grid.SetRow(rollMetal, 0);
            Grid.SetRow(list, 1);
            Grid.SetRow(stamping, 2);
            Grid.SetRow(casting, 3);

            foreach (Button element in MainGrid.Children)
            {
                element.Click += ButtonClicked;
            }
        }
    }
}