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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Operation { NO_OP, PLUS, MINUS, DIVIDE, MULTIPLY }
        private Operation currentOperation;
        private double input1;// left operand of the arithmetic operation
        private double input2;// right operand of the arithmetic operation
        private double result;// result of the arithmetic operation

        public MainWindow()
        {
            InitializeComponent();
            currentOperation = Operation.NO_OP;
        }

        #region Utility methods

        private void TypeDigit(string digit)
        {
            if (txtInput.Text == "0")// empty input
            {
                    txtInput.Text = digit;
            }
            else
            {      if (digit == ".") txtInput.Text = $"{txtInput.Text}{digit}";
            else
                    txtInput.Text = txtInput.Text + digit;  
            }
           // txtInput.Text = (txtInput.Text == "0") ? digit : txtInput.Text + digit;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
            currentOperation = Operation.NO_OP;
            input1 = input2 = 0;
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {

            if (double.TryParse(txtInput.Text, out input1))
            {
                string operation = (string)(((Button)sender).Content);
                switch (operation)
                {
                    case "+": currentOperation = Operation.PLUS; break;
                    case "-": currentOperation = Operation.MINUS; break;
                    case "*": currentOperation = Operation.MULTIPLY; break;
                    case "/": currentOperation = Operation.DIVIDE; break;
                }
                txtInput.Text = "0";
            }
            else
            {
                txtInput.Text = "0";
                MessageBox.Show("Wrong number.Repeat input.");
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            TypeDigit((string)(((Button)sender).Content));
        }
        /// <summary>
        /// Normal exit of application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(txtInput.Text, out input2))
            {
                switch (currentOperation)
                {
                    case Operation.NO_OP:
                        result = input2;
                        break;
                    case Operation.PLUS:
                        result = input1 + input2;
                        break;
                    case Operation.MINUS:
                        result = input1 - input2;
                        break;
                    case Operation.DIVIDE:
                        result = input1 / input2;
                        break;
                    case Operation.MULTIPLY:
                        result = input1 * input2;
                        break;
                    default:
                        break;
                }
                txtInput.Text = "" + result;
                currentOperation = Operation.NO_OP;
            }

        }
    }
}
