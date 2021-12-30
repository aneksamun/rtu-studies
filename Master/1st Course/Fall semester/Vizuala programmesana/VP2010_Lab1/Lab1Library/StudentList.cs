using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Lab1Library {
    public class StudentList {

        /// <summary>
        /// Noklusētais ceļš uz failu, kurā saglabāt studentu sarakstu.
        /// </summary>
        public const string DefaultFilename =
            @"C:\Users\neo\RTU\Master Studies\1st Course\Vizuala programmesana\Lab1\students.xml";

        /// <summary>
        /// Studentu saraksts.
        /// </summary>
        private List<Student> students = new List<Student>();

        public int Count { get { return students.Count; } }

        public Student this[int index] {
            get {
                if (index < 0 || index >= Count)
                    throw new Exception("Invalid student index !");

                return students[index];
            }
        }

        /// <summary>
        /// Pievieno sarakstam jaunu studentu.
        /// </summary>
        public void Add(Student newStud) {
            if (newStud != null)
                students.Add(newStud);
        }

        /// <summary>
        /// Saglabā failā tekošo studentu sarakstu.
        /// </summary>
        public void Save(string filename) {
            if (filename.Length == 0)
                filename = DefaultFilename;

            FileStream data = new FileStream(filename, FileMode.Create,
                FileAccess.Write);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                new Type[] { typeof(Student) });

            serializer.Serialize(data, students);
            data.Close();
        }

        /// <summary>
        /// Ielādē no faila studentu sarakstu.
        /// </summary>
        public void Load(string filename) {
            if (filename.Length == 0)
                filename = DefaultFilename;

            FileStream data = new FileStream(filename, FileMode.Open,
                FileAccess.Read);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                new Type[] { typeof(Student) });

            students = (List<Student>)serializer.Deserialize(data);
            data.Close();
        }
    }
}
