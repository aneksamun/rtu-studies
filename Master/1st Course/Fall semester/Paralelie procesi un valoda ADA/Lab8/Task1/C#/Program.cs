using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingTask {
    class Program {
        static void Main(string[] args) {
            int[,] matrix = { 
                      { 1, 2, 3, 4 },
                      { 5, 6, 7, 8 },
                      { 9, 10, 11, 12 },
                      { 13, 14, 15, 16 },
                      { 17, 18, 19, 20 },
                      { 21, 22, 23, 24 } };

            new MatrixThread(matrix, "Even", 0, ThreadPriority.Normal);
            new MatrixThread(matrix, "Odd", 1, ThreadPriority.Normal);

            Console.ReadLine();
        }
    }
}
