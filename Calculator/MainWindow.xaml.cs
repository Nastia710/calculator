using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using static Calculator.Command;
/*using Calculator.Commands;*/

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calculator;

        private readonly Button sqrt = new Button() 
        { 
            Content = "√",
            FontSize = 27,
            FontWeight = FontWeights.SemiBold,
            Margin = new Thickness(5),
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF9F9F9"))
        };
        private readonly Button pow = new Button() 
        { 
            Content = "xⁿ",
            FontSize = 27,
            FontWeight = FontWeights.SemiBold,
            Margin = new Thickness(5),
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF9F9F9"))
        };
        private readonly Button ln = new Button() 
        { 
            Content = "ln",
            FontSize = 27,
            FontWeight = FontWeights.SemiBold,
            Margin = new Thickness(5),
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF9F9F9"))
        };

        private bool isExpanded = false;
        private double originalWidth;

        public MainWindow()
        {
            InitializeComponent();

            calculator = new Calculator();

            Update();

            originalWidth = Width;

            Grid.SetColumn(sqrt, 4);
            Grid.SetRow(sqrt, 1);
            Grid.SetColumn(pow, 4);
            Grid.SetRow(pow, 2);
            Grid.SetColumn(ln, 4);
            Grid.SetRow(ln, 3);

            Style buttonStyle = (Style)FindResource(typeof(Button));
            sqrt.Style = buttonStyle;
            pow.Style = buttonStyle;
            ln.Style = buttonStyle;
        }

        private void SandwichButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isExpanded)
            {
                Width = originalWidth + 90;
                grid.ColumnDefinitions[4].Width = new GridLength(1, GridUnitType.Star);
                
                SandwichButton.Content = "<";
                SandwichButton.Click += Return;
                SandwichButton.Click -= SandwichButton_Click;

                Grid.SetColumn(RedoBtn, 4);
                Grid.SetColumnSpan(RedoBtn, 1);
                RedoBtn.HorizontalAlignment = HorizontalAlignment.Center;

                grid.Children.Add(sqrt);
                grid.Children.Add(pow);
                grid.Children.Add(ln);

                isExpanded = true;
            }
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            if (isExpanded)
            {
                Width = originalWidth;
                grid.ColumnDefinitions[4].Width = GridLength.Auto;

                SandwichButton.Content = "☰";
                SandwichButton.Click -= Return;
                SandwichButton.Click += SandwichButton_Click;

                Grid.SetColumn(RedoBtn, 3);
                Grid.SetColumnSpan(RedoBtn, 1);
                RedoBtn.HorizontalAlignment = HorizontalAlignment.Center;

                grid.Children.Remove(sqrt);
                grid.Children.Remove(pow);
                grid.Children.Remove(ln);

                isExpanded = false;
            }
        }

        private void Update()
        {
            waitingDisplay.Text = calculator.Expression;
            display.Text = calculator.DisplayText;
        }

        private void CBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            calculator.Undo();
            Update();
        }

        private void BackspaceBtn_Click(object sender, RoutedEventArgs e)
        {
            if(calculator.IsError)
            {
                return;
            }
            if(!calculator.IsNewOp && calculator.DisplayText.Length > 0)
            {

            }
        }
    }
}