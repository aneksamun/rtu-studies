using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Calculator.Common;

namespace Calculator {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        #region [ private members ]

        private MathOperations operation;
        private bool performClean, takeLast;
        private decimal current, previous, last;

        #endregion

        #region [ ctors ]

        public MainWindow() {
            InitializeComponent();
            current = previous = last = 0M;
            operation = MathOperations.Default;
        }

        #endregion

        #region [ event handlers ]

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            btnZero.Click += btnClick;
            btnOne.Click += btnClick;
            btnTwo.Click += btnClick;
            btnThree.Click += btnClick;
            btnFour.Click += btnClick;
            btnFive.Click += btnClick;
            btnSix.Click += btnClick;
            btnSeven.Click += btnClick;
            btnEight.Click += btnClick;
            btnNine.Click += btnClick;
        }

        void btnClick(object sender, RoutedEventArgs e) {

            var pressedButton = sender as Button;

            if (performClean) {
                txtDisplay.Clear();
                performClean = false;
            }

            try {
                current = decimal.Parse(txtDisplay.Text + pressedButton.Content.ToString());
                txtDisplay.Text = current.ToString();

            } catch (OverflowException ex) {
                MessageBox.Show(
                    ex.Message,
                    "Overflow error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            ForceAction(MathOperations.Add);
        }

        private void btnSubstract_Click(object sender, RoutedEventArgs e) {
            ForceAction(MathOperations.Substract);
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e) {
            ForceAction(MathOperations.Divide);
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e) {
            ForceAction(MathOperations.Multiply);
        }

        private void btnSign_Click(object sender, RoutedEventArgs e) {
            current = current > 0 ? -current : Math.Abs(current);
            txtDisplay.Text = current.ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            takeLast = false;
            txtDisplay.Text = "0";
            current = previous = last = 0M;
            operation = MathOperations.Default;
        }

        private void btnSeparator_Click(object sender, RoutedEventArgs e) {
            var separator =
                NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

            if (txtDisplay.Text.Contains(separator))
                return;

            txtDisplay.Text += separator;
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e) {

            if (takeLast) {
                previous = current;
                current = last;
            }

            try {
                switch (operation) {
                    case MathOperations.Add:
                        previous += current;
                        txtDisplay.Text = previous.ToString("G29");
                        break;
                    case MathOperations.Substract:
                        previous -= current;
                        txtDisplay.Text = previous.ToString("G29");
                        break;
                    case MathOperations.Divide:
                        previous /= current;
                        txtDisplay.Text = previous.ToString("G29");
                        break;
                    case MathOperations.Multiply:
                        previous *= current;
                        txtDisplay.Text = previous.ToString("G29");
                        break;
                    default:
                        break;
                }

                last = current;
                current = previous;
                takeLast = true;

            } catch (OverflowException ex) {
                MessageBox.Show(
                    ex.Message,
                    "Overflow error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            } catch (DivideByZeroException ex) {
                MessageBox.Show(
                    ex.Message,
                    "Divide by zero exception",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void AbouMenuItem_Click(object sender, RoutedEventArgs e) {
            new AboutWindow().ShowDialog();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        #endregion

        #region [ methods ]

        private void ForceAction(MathOperations operationToPerform) {
            operation = operationToPerform;
            performClean = true;

            // storing previous operand.
            previous = current;
            // preparing next operand.
            current = 0M;

            if (takeLast) takeLast = false;
        }

        #endregion
    }
}
