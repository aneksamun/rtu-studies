using System;
using System.Threading;

namespace CSharpThreading {
    class Program {
        static void Main() {
            int[,] matrix = {
                      { 1, 1, 1, 1, 1, 1, 1, 1 },
                      { 2, 2, 2, 2, 2, 2, 2, 2 },
                      { 3, 3, 3, 3, 3, 3, 3, 3 },
                      { 4, 4, 4, 4, 4, 4, 4, 4 },
                      { 5, 5, 5, 5, 5, 5, 5, 5 },
                      { 6, 6, 6, 6, 6, 6, 6, 6 },
                      { 7, 7, 7, 7, 7, 7, 7, 7 } };

            MatrixThread thread1 = new MatrixThread(matrix, 0, "Even", ThreadPriority.Normal, 0);
            MatrixThread thread2 = new MatrixThread(matrix, 1, "Odd", ThreadPriority.Highest, 0);

            thread1.GetThread.Start();
            thread2.GetThread.Start();

            thread1.GetThread.Join();
            thread2.GetThread.Join();

            Console.WriteLine("Total sum: {0}", thread1.Sum + thread2.Sum);
            Console.ReadLine();
        }
    }
}
