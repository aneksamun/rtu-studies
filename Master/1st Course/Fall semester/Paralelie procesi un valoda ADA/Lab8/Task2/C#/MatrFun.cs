using System;
using System.Threading;

namespace ThreadingTask {

    class MatrFun {
        public void PrintRow(int row, int[,] matrix) {
            // Outputting current row.
            Console.Write("Row: {0}. Elements: ", row);

            for (int j = 0; j < matrix.GetLength(1); j++) {
                // Getting row elements.
                Console.Write(matrix[row, j] + " ");
                Thread.Sleep(0);
            }

            Console.WriteLine();
        }
    }
}
