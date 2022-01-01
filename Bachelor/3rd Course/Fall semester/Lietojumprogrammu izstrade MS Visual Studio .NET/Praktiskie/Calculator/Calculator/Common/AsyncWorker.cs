using System;
using System.ComponentModel;
using System.Threading;

namespace Calculator.Common {
    /// <summary>
    /// Performs background work in asynchronous thread.
    /// </summary>
    public class AsyncWorker {
        bool completed;
        string errorDescription;

        /// <summary>
        /// The event to be fired upon operation completion
        /// </summary>
        public event EventHandler Complete;

        /// <summary>
        /// The event to be fired upon work unit completion
        /// </summary>
        public event EventHandler<ProgressSwitchedEventArgs> ProgressChanged;

        /// <summary>
        /// The operation is either completed successfully (true) or
        /// aborted due to exceptions (false).
        /// </summary>
        public bool Completed {
            get { return completed; }
        }

        /// <summary>
        /// The error text to be displayed in GUI in case of error
        /// (i.e. completed == false).
        /// </summary>
        public string ErrorDescription {
            get { return errorDescription; }
        }

        public AsyncWorker() {
            completed = false;
            errorDescription = string.Empty;
        }

        /// <summary>
        /// Starts the background work.
        /// </summary>
        public void Start() {
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            OnComplete(EventArgs.Empty);
        }

        /// <summary>
        /// Upon operation completion, fire a Complete event so that the 
        /// observer can receive and act on it.
        /// </summary>
        protected virtual void OnComplete(EventArgs e) {
            if (this.Complete != null) {
                this.Complete(this, e);
            }
        }

        /// <summary>
        /// Fires on progress unit change.
        /// </summary>
        private void OnProgressChanged(double progress) {
            if (ProgressChanged != null)
                ProgressChanged(this, new ProgressSwitchedEventArgs(progress));
        }

        void worker_DoWork(object sender, DoWorkEventArgs e) {
            try {
                for (var i = 1.0; i <= 100.0; i++) {
                    Thread.Sleep(100);
                    OnProgressChanged(i);
                }

                completed = true;
            } catch (Exception ex) {
                completed = false;
                errorDescription = ex.Message + "\n" + ex.StackTrace;
            }
        }
    }
}