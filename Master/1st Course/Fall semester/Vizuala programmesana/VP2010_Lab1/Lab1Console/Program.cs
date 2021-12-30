using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Library;

namespace Lab1Console {
    class Program {
        static void Main() {
            try {
                StudentList students = new StudentList();
                students.Load(StudentList.DefaultFilename);

                for (int i = 0; i < students.Count; i++)
                    System.Console.WriteLine(students[i]);

            } catch (Exception ex) {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.ReadLine();
        }
    }
}
