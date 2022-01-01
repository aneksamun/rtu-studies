using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using SchoolReport.BO;

namespace SchoolReport.Client.Utils {
    /// <summary>
    /// Interacts logic for student register management.
    /// </summary>
    public class StudentManager {

        /// <summary>
        /// The error text to be displayed in output in case of error.
        /// </summary>
        public string ErrorDescription { get; private set; }

        /// <summary>
        /// Stores student to binary file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="student">Student to register.</param>
        /// <returns>Execution success.</returns>
        public bool RegisterStudent(string fileName, Student student) {
            try {
                using (var stream = File.Open(fileName, FileMode.Append)) {
                    var binaryWriter = new BinaryFormatter();
                    binaryWriter.Serialize(stream, student);
                }
            } 
            catch (Exception ex) {
                ErrorDescription =
                    string.Format("Error occurred while saving student:\n{0}", ex.Message);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Reads students from binary.
        /// </summary>
        /// <param name="fileName">File to read.</param>
        /// <param name="students">Students to get.</param>
        /// <returns>Execution success.</returns>
        public bool ReadStudents(string fileName, ref Students students) {
            try {
                using (var stream = File.Open(fileName, FileMode.Open)) {
                    var binaryReader = new BinaryFormatter();

                    while (stream.Position != stream.Length) {
                        var student = (Student)binaryReader.Deserialize(stream);
                        students.Add(student);
                    }
                }
            } 
            catch (Exception ex) {
                ErrorDescription =
                    string.Format("Error occurred while reading source file {0}:\n{1}", fileName, ex.Message);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets students by mark criteria.
        /// </summary>
        /// <param name="fileName">File to read.</param>
        /// <param name="students">Students to get.</param>
        /// <param name="mark">Mark criteria.</param>
        /// <returns>Execution success.</returns>
        public bool GetStudentsByMark(string fileName, ref Students students, int mark) {
            if (!ReadStudents(fileName, ref students))
                return false;

            students = students.Where(
                s => s.FinalMarks.Count > 0 && s.FinalMarks.All(m => m.Mark >= mark)).ToStudents();

            return true;
        }
    }
}