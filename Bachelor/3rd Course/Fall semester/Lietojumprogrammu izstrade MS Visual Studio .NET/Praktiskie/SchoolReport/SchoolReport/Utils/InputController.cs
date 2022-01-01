using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SchoolReport.BO;

namespace SchoolReport.Client.Utils {
    /// <summary>
    /// Interacts logic of input
    /// </summary>
    public class InputController {

        /// <summary>
        /// Provides student registration interaction
        /// </summary>
        /// <returns>Entered student</returns>
        public static Student RegisterStudent() {
            string firstname, lastname;

            Console.WriteLine("Please enter following data:");

            for (;;) {
                Console.Write("Firstname: ");
                firstname = Console.ReadLine();

                if (!Student.IsValidAttribute(firstname)) {
                    Console.WriteLine("Firstname is invalid.");
                    continue;
                }

                break;
            }

            for (;;) {
                Console.Write("Lastname: ");
                lastname = Console.ReadLine();

                if (!Student.IsValidAttribute(lastname)) {
                    Console.WriteLine("Lastname is invalid.");
                    continue;
                }

                break;
            }

            var student = new Student(firstname, lastname);

            Console.Write("\nDo you want to enter subjects? (y/n) ");

            if (Console.ReadLine().ToLower() != "y") {
                Console.WriteLine();
                return student;
            }

            Console.WriteLine();

            while (true) {
                string subject;
                int finalMark;

                for (;;) {
                    Console.Write("Subject: ");
                    subject = Console.ReadLine();

                    if (FinalMark.IsValidSubject(subject))
                        break;

                    Console.WriteLine("Subject is invalid.");
                }

                for (;;) {
                    Console.Write("Final mark: ");
                    var mark = Console.ReadLine();

                    if (int.TryParse(mark, out finalMark) &&
                        FinalMark.IsValidMark(finalMark))
                        break;

                    Console.WriteLine("Final mark is invalid.");
                }

                student.FinalMarks.Add(new FinalMark(subject, finalMark));

                Console.Write("\nEnter new subject? (y/n) ");

                if (Console.ReadLine().ToLower() != "y")
                    break;

                Console.WriteLine();
            }

            Console.WriteLine();

            return student;
        }

        /// <summary>
        /// Edits file name extension 
        /// </summary>
        /// <param name="fileName">File name to edit</param>
        /// <returns>Edited file name</returns>
        public static string EditExtension(string fileName) {
            const string extension = "bin";
            var fileExtension = Path.GetExtension(fileName);

            if (!string.IsNullOrEmpty(fileExtension))
                fileName = fileName.Replace(fileExtension, string.Empty);

            while (!string.IsNullOrEmpty(fileName) && fileName.Last().Equals('.'))
                fileName = fileName.Remove(fileName.Length - 1, 1);

            return string.Format("{0}.{1}", string.IsNullOrEmpty(fileName) ? "student" : fileName, extension);
        }

        /// <summary>
        /// Displays students.
        /// </summary>
        /// <param name="students">Students to display</param>
        public static void DisplayStudents(Students students) {

            if (students == null || students.Count == 0) {
                Console.WriteLine("There is no any student to display yet!");
                return;
            }

            Console.WriteLine(students.ToString());
        }

        /// <summary>
        /// Encapsulates mark input logic.
        /// </summary>
        /// <returns>Mark</returns>
        public static int EnterMark() {
            string tmp;
            int mark;

            for (;;) {
                Console.Write("Mark criteria: ");
                tmp = Console.ReadLine();

                if (!int.TryParse(tmp, out mark) || !FinalMark.IsValidMark(mark)) {
                    Console.WriteLine("Mark is invalid.\n");
                    continue;
                }

                return mark;
            }
        }
    }
}
