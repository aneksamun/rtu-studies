using System;
using SchoolReport.BO;
using SchoolReport.Client.Common;
using SchoolReport.Client.Utils;

namespace SchoolReport.Client {
    /// <summary>
    /// Interacts logic for student report client.
    /// </summary>
    class Report {

        static void Main(string[] args) {

            var fileName = args.Length > 0 && !string.IsNullOrEmpty(args[0]) ? args[0] : "students.bin";

            if (args.Length > 1) {
                Console.WriteLine("Unexpected program launch.");
                Console.WriteLine("Syntax: SchoolReport [result file name] or");
                Console.WriteLine("\tSchoolReport (to use default name: {0})", fileName);
                return;
            }

            OperationType operation;

            while (true) {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("            Students achievements            ");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("[1] Enter information about new student");
                Console.WriteLine("[2] View students");
                Console.WriteLine("[3] View students (marks >= criteria)");
                Console.WriteLine("[4] Exit application\n");
                Console.Write("Choice -> ");

                var choice = Console.ReadLine();

                if (!Enum.TryParse<OperationType>(choice, out operation)) {
                    Console.WriteLine("\r\nInvalid choice.\nPlease, enter valid option [1 - 4].");
                    Console.Write("Press any key to continue...");
                    Console.ReadLine();
                    continue;
                }

                if (operation == OperationType.Exit)
                    break;

                Console.WriteLine();

                switch (operation) {
                    case OperationType.EnterStudent:
                        var student = InputController.RegisterStudent();

                        var studentManager = new StudentManager();

                        if (!studentManager.RegisterStudent(fileName, student)) {
                            Console.WriteLine(studentManager.ErrorDescription);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPlease, enter any key to continue...");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Student has been saved successfully.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadKey();

                        break;
                    case OperationType.ViewStudents:
                        var manager = new StudentManager();
                        var students = new Students();

                        if (!manager.ReadStudents(fileName, ref students)) {
                            Console.WriteLine(manager.ErrorDescription);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPlease, enter any key to continue...");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.ReadKey();
                            break;
                        }

                        InputController.DisplayStudents(students);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadKey();

                        break;
                    case OperationType.ViewStudentsByMark:
                        var m = new StudentManager();
                        var s = new Students();
                        var mark = InputController.EnterMark();

                        Console.WriteLine();

                        if (!m.GetStudentsByMark(fileName, ref s, mark)) {
                            Console.WriteLine(m.ErrorDescription);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPlease, enter any key to continue...");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.ReadKey();
                            break;
                        }

                        InputController.DisplayStudents(s);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadKey();

                        break;
                }
            }
        }
    }
}
