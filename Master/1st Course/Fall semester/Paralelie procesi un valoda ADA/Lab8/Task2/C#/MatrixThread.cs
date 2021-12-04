using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingTask {

    class MatrixThread {
        // Private class members.
        private Thread thread;
        private int[,] matrix;
        private int startRow;
        MatrFun matrFun;

        public MatrixThread(
            int[,] matr,
            string name,
            int row,
            ThreadPriority priority,
            MatrFun objMatr) {

                matrix = matr;
                startRow = row;
                matrFun = objMatr;

                thread = new Thread(this.Run);
                thread.Name = name;
                thread.Priority = priority;
                thread.Start();
        }

        private void Run() {
            // Synchronizing or locking object.
            for (int i = startRow; i < matrix.GetLength(0); i += 2) {
                lock (this.matrFun) {
                    matrFun.PrintRow(i, matrix);
                }
            }
        }
    }
}
