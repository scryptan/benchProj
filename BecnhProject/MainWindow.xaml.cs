using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
                return C * ChipMass / Q;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public decimal Coef = 1;

        public decimal ResultSum => Sum() * Coef * ModelCount + MaterialCost;

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

        public LinearGradientBrush blueGradientBrush;
        public LinearGradientBrush greenGradientBrush;

        private readonly FillPage _fillPage;
        private readonly BenchChoose _benchChoose;
        private readonly MaterialChoose _materialChoose;
        private readonly BlankChoose _blankChoose;
        private readonly ParametersChoose _parametersChoose;
        private readonly TechChoose _techChoose;
        private readonly Result _result;

        private Dictionary<MaterialType, decimal> _density = new()
        {
            {MaterialType.NonAlloySteel, 7800},
            {MaterialType.AlloySteel, 7800},
            {MaterialType.HighAlloySteel, 7800},
            {MaterialType.StainlessSteelBar, 8000},
            {MaterialType.StainlessSteelCast, 8000},
            {MaterialType.HeatResistanceTitan, 5000},
            {MaterialType.HeatResistanceChecked, 7800},
            {MaterialType.CastIron, 7800},
            {MaterialType.SuperHardSteel, 7800},
            {MaterialType.Aluminium, 2700},
        };

        private Dictionary<(MaterialType, BenchModel), BenchCharacteristics> _benchCharacteristics = new()
        {
            {
                (MaterialType.NonAlloySteel, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 180,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.NonAlloySteel, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = 225,
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
            {
                (MaterialType.AlloySteel, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 180,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.AlloySteel, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = 225,
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
            {
                (MaterialType.HighAlloySteel, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 120,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.HighAlloySteel, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = 150,
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
            {
                (MaterialType.StainlessSteelBar, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 100,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.StainlessSteelBar, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = 125,
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
            {
                (MaterialType.StainlessSteelCast, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 100,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.StainlessSteelCast, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = 125,
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
            {
                (MaterialType.HeatResistanceTitan, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 100,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.HeatResistanceTitan, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = 125,
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
            {
                (MaterialType.HeatResistanceChecked, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 100,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.HeatResistanceChecked, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = 125,
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
            {
                (MaterialType.CastIron, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 150,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.CastIron, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = new decimal(187.5),
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
            {
                (MaterialType.SuperHardSteel, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 200,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.SuperHardSteel, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = 250,
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
            {
                (MaterialType.Aluminium, BenchModel.Ctx310), new BenchCharacteristics
                {
                    V = 300,
                    S = new decimal(0.2),
                    T = new decimal(1.5),
                }
            },
            {
                (MaterialType.Aluminium, BenchModel.Ctx510), new BenchCharacteristics
                {
                    V = 375,
                    S = new decimal(0.2),
                    T = new decimal(3),
                }
            },
        };

        private decimal CalcLength => BlankLength + 5;
        
        public decimal V => BlankHeight > 0
            ? CalcLength * BlankHeight * BlankDiameter / 1_000_000
            : CalcLength * (decimal) Math.PI * BlankDiameter * BlankDiameter / 4 / 1_000_000;

        public decimal BlankMass => V * (_density.ContainsKey(MaterialType) ?_density[MaterialType]: 0) / 1000;
        public decimal ChipMass => BlankMass - BlueprintMass;
        public int C = 3000;
        public decimal Q => _benchCharacteristics[(MaterialType, BenchModel)].GetValue() * _density[MaterialType] * 60 / 1_000_000;

        public MainWindow()
        {
            _fillPage = new FillPage(this);
            _benchChoose = new BenchChoose(this);
            _materialChoose = new MaterialChoose(this);
            _blankChoose = new BlankChoose(this);
            _parametersChoose = new ParametersChoose(this);
            _techChoose = new TechChoose(this);
            _result = new Result(this);

            blueGradientBrush = new LinearGradientBrush(Color.FromRgb(179, 195, 236), Color.FromRgb(21, 73, 206), 90);
            greenGradientBrush = new LinearGradientBrush(Color.FromRgb(179, 236, 195), Color.FromRgb(21, 190, 71), 90);

            InitializeComponent();
            MainFrame.Navigate(_fillPage);
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
            SetAllMenuButtonsBlue();
            SetButtonGreen(BenchButton);
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
            SetAllMenuButtonsBlue();
            SetButtonGreen(MaterialButton);
        }

        public void SetBlankWindow()
        {
            _blankChoose.Init();
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
            SetAllMenuButtonsBlue();
            SetButtonGreen(BlankButton);
        }

        public void SetParametersWindow()
        {
            _parametersChoose.Init();
            MainFrame.Navigate(_parametersChoose);

            BlankButton.Content = BlankType.ToDescriptionString();

            TechButton.Content = string.Empty;
            ParametersButton.Content = string.Empty;
            SetAllMenuButtonsBlue();
            SetButtonGreen(ParametersButton);
        }

        public void SetTechWindow()
        {
            _techChoose.Init();
            MainFrame.Navigate(_techChoose);
            Coef = 1;

            ParametersButton.Content = "Задание параметров";

            TechButton.Content = string.Empty;
            SetAllMenuButtonsBlue();
            SetButtonGreen(TechButton);
        }

        public void SetResultWindow()
        {
            if (ResultSum < 0)
            {
                SetParametersWindow();
                return;
            }

            TechButton.Content = "Дополнительные параметры";
            _result.Init();
            MainFrame.Navigate(_result);
            SetAllMenuButtonsBlue();
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

        private void SetAllMenuButtonsBlue()
        {
            BenchButton.Background = blueGradientBrush;
            MaterialButton.Background = blueGradientBrush;
            BlankButton.Background = blueGradientBrush;
            ParametersButton.Background = blueGradientBrush;
            TechButton.Background = blueGradientBrush;
        }

        private void SetButtonGreen(Button button)
        {
            button.Background = greenGradientBrush;
        }
    }
}