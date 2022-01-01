using System;

namespace Calculator.Common {
    /// <summary>
    /// Reports about current progress changed unit. 
    /// </summary>
    public class ProgressSwitchedEventArgs : EventArgs {

        /// <summary>
        /// Gets or sets the progress unit.
        /// </summary>
        public double ProgressPercentage { get; set; }

        public ProgressSwitchedEventArgs(double progressPercentage) {
            ProgressPercentage = progressPercentage;
        }
    }
}
