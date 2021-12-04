using System;
using System.Threading;

namespace ThreadingTask {

    class MatrixThread {
        // Private class members.
        private Thread thread;
        private int[,] matrix;
        private int startRow;

        public MatrixThread(
            int[,] matr,
            string name,
            int row,
            ThreadPriority priority) {

                matrix = matr;
                startRow = row;

                thread = new Thread(this.Run);
                thread.Name = name;
                thread.Priority = priority;
                thread.Start();
        }

        private void Run() {
            // Calling synchronized static method.
            for (int i = startRow; i < matrix.GetLength(0); i += 2)
                MatrFun.PrintRow(i, matrix);
        }
    }
}
