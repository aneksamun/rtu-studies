using System;

namespace Lab1Library {
    [Serializable]
    public class Student {

        /// <summary>
        /// Studenta vārds.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Studenta uzvārds.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Studenta apliecības numurs.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Studenta grupa.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Studenta e-pasts.
        /// </summary>
        public string Email { get; set; }

        private Student() {}

        public Student(string name, string surname, string id,
            string group, string e_mail) {

            if (name.Length == 0 ||
                surname.Length == 0 ||
                id.Length == 0 ||
                group.Length == 0 ||
                e_mail.Length == 0)
                throw new Exception("Invalid student data!");

            this.Name = name;
            this.Surname = surname;
            this.Id = id;
            this.Group = group;
            this.Email = e_mail;
        }

        public override string ToString() {
            return Id + " : " + Name + " " + Surname + ", " + Group + ", " + Email + ".";
        }
    }
}
