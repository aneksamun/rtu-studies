using System;
using System.Linq;

namespace SchoolReport.BO {
    /// <summary>
    /// Interacts logic for the mark.
    /// </summary>
    [Serializable]
    public struct FinalMark {

        #region [ properties ]

        /// <summary>
        /// Gets the subject.
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// Gets the final mark.
        /// </summary>
        public int Mark { get; private set; }

        #endregion

        #region [ ctors ]

        public FinalMark(string subject, int mark)
            : this() {

            if (!IsValidSubject(subject))
                throw new ArgumentNullException("subject", @"Can't contain none letter value or be null or empty");

            if (!IsValidMark(mark))
                throw new ArgumentOutOfRangeException("mark", @"Must be between 1 and 10 including");

            Subject = subject;
            Mark = mark;
        }

        #endregion

        #region [ public methods ]

        /// <summary>
        /// Indicates either mark is valid.
        /// </summary>
        /// <param name="mark">Mark to validate.</param>
        /// <returns>Mark authenticity.</returns>
        public static bool IsValidMark(int mark) {
            return mark > 0 && mark < 11;
        }

        /// <summary>
        /// Indicates whether attribute is valid
        /// </summary>
        /// <param name="attribute">Attribute to validate</param>
        /// <returns>Attribute authenticity</returns>
        public static bool IsValidSubject(string attribute) {
            return (!string.IsNullOrEmpty(attribute) && !attribute.Any(ch => !char.IsLetter(ch)));
        }

        /// <summary>
        /// Returns formatted final mark string.
        /// </summary>
        /// <returns>Formatted final mark string</returns>
        public override string ToString() {
            return string.Format("{0}({1})", Subject, Mark);
        }

        #endregion
    }
}
