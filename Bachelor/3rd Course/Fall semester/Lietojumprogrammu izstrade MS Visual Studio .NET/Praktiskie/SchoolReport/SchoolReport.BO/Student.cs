using System;
using System.Collections;
using System.Linq;

namespace SchoolReport.BO {
    /// <summary>
    /// Interacts logic for the student.
    /// </summary>
    [Serializable]
    public class Student {

        #region [ private members ]

        private string _firstname, _lastname;

        #endregion

        #region [ properties ]

        /// <summary>
        /// Gets the firstname.
        /// </summary>
        public string Firstname {
            get { return _firstname; }
        }

        /// <summary>
        /// Gets the lastname.
        /// </summary>
        public string Lastname {
            get { return _lastname; }
        }

        /// <summary>
        /// Gets or sets the final marks.
        /// </summary>
        public Marks FinalMarks { get; set; }

        #endregion

        #region [ ctors ]

        public Student(string firstname, string lastname, Marks finalMarks = null) {

            if (!IsValidAttribute(firstname))
                throw new ArgumentNullException("Firstname", "Can't contain none letter value or be null or empty");

            if (!IsValidAttribute(lastname))
                throw new ArgumentNullException("Lastname", "Can't contain none letter value or be null or empty");

            foreach (var ch in ConvertToTitleCase(firstname))
                _firstname += ch;

            foreach (var ch in ConvertToTitleCase(lastname))
                _lastname += ch;

            FinalMarks = finalMarks ?? new Marks();
        }

        #endregion

        #region [ methods ]

        private static IEnumerable ConvertToTitleCase(string name) {
            for (var i = 0; i < name.Length; i++)
                yield return (i == 0)
                    ? char.ToUpper(name[i])
                    : char.ToLower(name[i]); 
        }

        /// <summary>
        /// Indicates whether attribute is valid.
        /// </summary>
        /// <param name="attribute">Attribute to validate</param>
        /// <returns>Attribute authenticity</returns>
        public static bool IsValidAttribute(string attribute) {
            return (!string.IsNullOrEmpty(attribute) && !attribute.Any(ch => !char.IsLetter(ch))); 
        }

        /// <summary>
        /// Returns formatted student string.
        /// </summary>
        /// <returns>Formatted student string</returns>
        public override string ToString() {
            return string.Format("| {0,-13}| {1,-13}| {2}\n", Firstname, Lastname, FinalMarks.ToString());
        }

        #endregion
    }
}
