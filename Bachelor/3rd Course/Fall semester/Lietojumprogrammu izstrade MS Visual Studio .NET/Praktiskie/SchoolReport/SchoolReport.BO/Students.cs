using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolReport.BO {
    /// <summary>
    /// Interacts logic for the student collection.
    /// </summary>
    [Serializable]
    public class Students : BaseItems<Student> {

        #region [ ctors ]

        public Students() : base() {}

        public Students(IList<Student> students)
            : base(students) {
        }

        #endregion

        #region [ public methods ]

        /// <summary>
        /// Formats students output string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {

            var s = new StringBuilder();
            var marksToStringLen = new int[_items.Count];

            for (var i = 0; i < _items.Count; i++) {
                s.Append(_items[i].ToString());
                marksToStringLen[i] = _items[i].FinalMarks.Length + 1;
            }

            var maxRange = marksToStringLen.Max();
            const int defaultRangeToAppend = 12;
            var separator = new String(
                '-', 32 + (maxRange > defaultRangeToAppend ? maxRange : defaultRangeToAppend));

            s.Insert(0, separator + "\n");
            s.Insert(0, string.Format("| {0,-13}| {1,-13}| {2}\n", "Firstname", "Lastname", "Final marks"));
            s.Insert(0, separator + "\n");

            return s.ToString();
        }

        #endregion
    }
}
