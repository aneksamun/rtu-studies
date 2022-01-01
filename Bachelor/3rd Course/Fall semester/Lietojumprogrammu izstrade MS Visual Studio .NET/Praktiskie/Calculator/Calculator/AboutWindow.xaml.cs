using System.Reflection;
using System.Windows;

namespace Calculator {
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window {
        public AboutWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly.GetName().Version;

            lblVersion.Content += version.ToString();
        }
    }
}
