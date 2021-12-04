using System;
using System.Threading;

namespace CSharpThreading {
    class MatrixThread {
        public Thread thread;
        private int[,] matrix;
        private int delay, row, sum;

        public Thread GetThread { get { return thread; } }
        public int Sum { get { return sum; } }

        public MatrixThread(
            int[,] matr,
            int startRow,
            string name,
            ThreadPriority priority,
            int delay) {

            sum = 0;
            matrix = matr;
            row = startRow;
            this.delay = delay;

            thread = new Thread(this.Run);
            thread.Name = name;
            thread.Priority = priority;
        }

        void Run() {
            for (int i = row; i < matrix.GetLength(0); i += 2)
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    sum += matrix[i, j];

                    Thread.Sleep(delay);
                }

            Console.WriteLine("Thread[{0}, {1}], Sum: {2}",
                Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority, sum);
        }
    }
}
