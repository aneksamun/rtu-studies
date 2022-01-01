using System;
using System.Windows;
using System.Windows.Threading;
using Calculator.Common;

namespace Calculator {
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window {
        AsyncWorker worker;

        public SplashScreen(AsyncWorker asyncWorker) {
            InitializeComponent();

            worker = asyncWorker;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.Complete += worker_Complete;
        }

        void worker_ProgressChanged(object sender, ProgressSwitchedEventArgs e) {
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                new Action(
                    delegate {
                        progressBar.Value = e.ProgressPercentage;
                        lblProgress.Content = e.ProgressPercentage + "%";
                    }));
        }

        void worker_Complete(object sender, EventArgs e) {
            if (worker.Completed) {
                var mw = new MainWindow();
                Close();
                mw.Show();
            } 
            else {
                MessageBox.Show("Cannot initialise application:\n" + worker.ErrorDescription,
                    "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);

                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            worker.Start();
        }
    }
}
