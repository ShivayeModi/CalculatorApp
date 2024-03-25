using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber;
        double result;
        double newNumber;

        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            OutputLabel.Content = "0";
            acButton.Click += AcButton_Click;
            plusOrminus.Click += NegativeButton_Click;
            percentButton.Click += PercentButton_Click;
            equalButton.Click += EqualButton_Click;
            decimalButton.Click += DecimalButton_Click;
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!OutputLabel.Content.ToString().Contains("."))
            {
                OutputLabel.Content += ".";
            }
            
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {

            newNumber = double.Parse(OutputLabel.Content.ToString());
            
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        Debug.Print(result.ToString());
                        OutputLabel.Content = result.ToString();
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        OutputLabel.Content = result.ToString();
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        OutputLabel.Content = result.ToString();
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        OutputLabel.Content = result.ToString();
                        break;
                    default:
                        break;
                }
            
           
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(OutputLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                OutputLabel.Content = lastNumber.ToString();

            }

        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(OutputLabel.Content.ToString(),out lastNumber))
            {
                lastNumber = lastNumber * (-1);
                OutputLabel.Content = lastNumber.ToString();

            }
            
        }

        private void operationButton_click(object sender , RoutedEventArgs e)
        {
            lastNumber = double.Parse(OutputLabel.Content.ToString());
            Button button = (Button)sender;
            if (button == addButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            if (button == minusButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            if (button ==  multiplyButton)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            if (button == divisionButton)
            {
                selectedOperator = SelectedOperator.Division;
            }

            OutputLabel.Content = "0";

            
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            OutputLabel.Content = "0";
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            Button button = (Button)sender;
            
            if (OutputLabel.Content.ToString() == "0")
            {
                OutputLabel.Content = selectedValue.ToString();
            }
            else
            {
                OutputLabel.Content += selectedValue.ToString();
            }

        }
    }

    public enum SelectedOperator
    {
        Addition,Subtraction,Multiplication,Division
    }

    public  class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            if (n2==0) {

                MessageBox.Show("Invalid Operation","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        }


    }
}
