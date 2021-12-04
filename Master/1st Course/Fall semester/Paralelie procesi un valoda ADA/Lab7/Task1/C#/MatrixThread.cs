using System;
using System.Threading;

namespace CSharpThreading {
    class MatrixThread {
        public Thread thread;
        private int[,] matrix;
        private int delay, row;

        public MatrixThread(
            int[,] matr,
            int startRow,
            string name,
            ThreadPriority priority,
            int delay) {

            matrix = matr;
            row = startRow;
            this.delay = delay;

            thread = new Thread(this.Run);
            thread.Name = name;
            thread.Priority = priority;
            thread.Start();
        }

        void Run() {
            int sum = 0;

            for (int i = row; i < matrix.GetLength(0); i += 2) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    sum += matrix[i, j];

                    Thread.Sleep(delay);
                }

                Console.WriteLine("Thread[{0}, {1}]. Row: {2}, Sum: {3}",
                    Thread.CurrentThread.Name, 
                    Thread.CurrentThread.Priority, i, sum);

                sum = 0;
            }
        }
    }
}
