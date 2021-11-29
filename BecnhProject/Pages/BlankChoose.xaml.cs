using System;
using System.Windows;
using System.Windows.Controls;
using BecnhProject.Extensions;
using BecnhProject.Models;

namespace BecnhProject.Pages
{
    public partial class BlankChoose : Page
    {
        private readonly MainWindow _mainWindow;

        public BlankChoose(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var casting = new Button
            {
                Name = $"{BlankType.Casting}Button",
                Content = BlankType.Casting.ToDescriptionString(),
            };
            MainGrid.Children.Add(casting);
            var list = new Button
            {
                Name = $"{BlankType.List}Button",
                Content = BlankType.List.ToDescriptionString(),
            };
            MainGrid.Children.Add(list);
            var stamping = new Button
            {
                Name = $"{BlankType.Stamping}Button",
                Content = BlankType.Stamping.ToDescriptionString(),
            };
            MainGrid.Children.Add(stamping);
            var rollMetal = new Button
            {
                Name = $"{BlankType.RollMetal}Button",
                Content = BlankType.RollMetal.ToDescriptionString(),
            };
            MainGrid.Children.Add(rollMetal);
            Grid.SetRow(casting, 0);
            Grid.SetRow(list, 1);
            Grid.SetRow(stamping, 2);
            Grid.SetRow(rollMetal, 3);

            foreach (Button element in MainGrid.Children)
            {
                element.Click += ButtonClicked;
            }
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            var blankType = Enum.Parse<BlankType>(((Button) sender).Name.Replace("Button", ""));
            _mainWindow.BlankType = blankType;
            _mainWindow.SetParametersWindow();
        }
    }
}