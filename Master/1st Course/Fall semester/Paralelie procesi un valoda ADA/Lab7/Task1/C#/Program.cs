using System;
using System.Threading;

namespace CSharpThreading {
    class Program {
        static void Main(string[] args) {
            int[,] matrix = {
                      { 1, 1, 1, 1, 1, 1, 1, 1 },
                      { 2, 2, 2, 2, 2, 2, 2, 2 },
                      { 3, 3, 3, 3, 3, 3, 3, 3 },
                      { 4, 4, 4, 4, 4, 4, 4, 4 },
                      { 5, 5, 5, 5, 5, 5, 5, 5 },
                      { 6, 6, 6, 6, 6, 6, 6, 6 },
                      { 7, 7, 7, 7, 7, 7, 7, 7 } };

            new MatrixThread(matrix, 0, "Even", ThreadPriority.Normal, 0);
            new MatrixThread(matrix, 1, "Odd", ThreadPriority.Highest, 0);

            Console.ReadLine();
        }
    }
}
