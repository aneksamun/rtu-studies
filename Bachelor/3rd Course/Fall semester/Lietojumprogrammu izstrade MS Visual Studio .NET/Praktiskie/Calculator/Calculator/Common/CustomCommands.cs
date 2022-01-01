using System.Windows.Input;

namespace Calculator.Common {

    /// <summary>
    /// Defines custom commands
    /// </summary>
    static class CustomCommands {
        /// <summary>
        /// Routed command to open about window
        /// </summary>
        public static RoutedCommand AboutCommand = new RoutedCommand();
    }
}
