using System.Windows;
using Calculator.Common;

namespace Calculator {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private void Application_Startup(object sender, StartupEventArgs e) {
            var splash = new SplashScreen(new AsyncWorker());
            splash.Show();
        }
    }
}
