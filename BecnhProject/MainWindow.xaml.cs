using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BecnhProject.Extensions;
using BecnhProject.Models;
using BecnhProject.Pages;

namespace BecnhProject
{
    public partial class MainWindow : Window
    {
        public decimal Sum()
        {
            try
            {
                return C / ChipMass / Q;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public decimal ResultSum = 0;

        public BenchModel BenchModel;
        public MaterialType MaterialType;
        public BlankType BlankType;

        public decimal BlankLength;
        public decimal BlankHeight = -1;
        public decimal BlankDiameter;

        public decimal BlueprintMass;
        public decimal ModelCount;

        public bool IsFree;
        public decimal MaterialCost;

        private readonly BenchChoose _benchChoose;
        private readonly MaterialChoose _materialChoose;
        private readonly BlankChoose _blankChoose;
        private readonly ParametersChoose _parametersChoose;
        private readonly TechChoose _techChoose;
        private readonly Result _result;

        private Dictionary<MaterialType, decimal> _density = new()
        {
        };

        private Dictionary<MaterialType, BenchCharacteristics> _benchCharacteristics = new()
        {
        };

        public decimal V => BlankHeight != -1
            ? BlankLength * BlankHeight * BlankDiameter
            : BlankLength * (decimal) Math.PI * BlankDiameter * BlankDiameter / 4;

        public decimal BlankMass => V * _density[MaterialType];
        public decimal ChipMass => BlankMass - BlueprintMass;
        public int C = 3000;
        public decimal Q => _benchCharacteristics[MaterialType].GetValue() * _density[MaterialType];

        public MainWindow()
        {
            _benchChoose = new BenchChoose(this);
            _materialChoose = new MaterialChoose(this);
            _blankChoose = new BlankChoose(this);
            _parametersChoose = new ParametersChoose(this);
            _techChoose = new TechChoose(this);
            _result = new Result();

            InitializeComponent();
            SetStartScreen();
        }

        public void SetStartScreen()
        {
            MainFrame.Navigate(_benchChoose);
            BenchButton.Content = string.Empty;
            MaterialButton.Content = string.Empty;
            BlankButton.Content = string.Empty;
            TechButton.Content = string.Empty;
            ParametersButton.Content = string.Empty;

            BlankLength = 0;
            BlankHeight = 0;
            BlankDiameter = 0;
            BlueprintMass = 0;
            ModelCount = 0;
        }

        public void SetMaterialWindow()
        {
            _materialChoose.Init();
            MainFrame.Navigate(_materialChoose);
            BenchButton.Content = BenchModel;
            MaterialButton.Content = string.Empty;
            BlankButton.Content = string.Empty;
            TechButton.Content = string.Empty;
            ParametersButton.Content = string.Empty;

            BlankLength = 0;
            BlankHeight = 0;
            BlankDiameter = 0;
            BlueprintMass = 0;
            ModelCount = 0;
        }

        public void SetBlankWindow()
        {
            MainFrame.Navigate(_blankChoose);
            MaterialButton.Content = MaterialType.ToDescriptionString();
            BlankButton.Content = string.Empty;
            TechButton.Content = string.Empty;
            ParametersButton.Content = string.Empty;

            BlankLength = 0;
            BlankHeight = 0;
            BlankDiameter = 0;
            BlueprintMass = 0;
            ModelCount = 0;
        }

        public void SetParametersWindow()
        {
            _parametersChoose.Init();
            MainFrame.Navigate(_parametersChoose);
            BlankButton.Content = BlankType.ToDescriptionString();
            TechButton.Content = string.Empty;
            ParametersButton.Content = string.Empty;
        }

        public void SetTechWindow()
        {
            _techChoose.Init();
            MainFrame.Navigate(_techChoose);
            ParametersButton.Content = "Задание параметров";
            TechButton.Content = string.Empty;
        }

        public void SetResultWindow()
        {
            _result.Init();
            MainFrame.Navigate(_result);
            ParametersButton.Content = string.Empty;
        }

        private void BenchButton_OnClick(object sender, RoutedEventArgs e)
        {
            SetStartScreen();
        }

        private void MaterialButton_OnClick(object sender, RoutedEventArgs e)
        {
            SetMaterialWindow();
        }

        private void BlankButton_OnClick(object sender, RoutedEventArgs e)
        {
            SetBlankWindow();
        }

        private void ParametersButton_OnClick(object sender, RoutedEventArgs e)
        {
            SetParametersWindow();
        }

        private void TechButton_OnClick(object sender, RoutedEventArgs e)
        {
            SetTechWindow();
        }
    }
}