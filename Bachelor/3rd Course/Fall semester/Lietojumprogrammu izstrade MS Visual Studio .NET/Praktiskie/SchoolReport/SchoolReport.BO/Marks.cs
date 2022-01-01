using System;
using System.Collections.Generic;

namespace SchoolReport.BO {
    /// <summary>
    /// Interacts logic for the marks collection.
    /// </summary>
    [Serializable]
    public class Marks : BaseItems<FinalMark> {

        #region [ private members ]

        private int _len;

        #endregion

        #region [ properties ]

        /// <summary>
        /// Gets the length of the formatted marks
        /// </summary>
        internal int Length {
            get {
                return _len;
            }
        }

        #endregion

        #region [ ctors ]

        public Marks() : base() {}

        public Marks(IList<FinalMark> marks)
            : base(marks) {
        }

        #endregion

        #region [ public members ]

        /// <summary>
        /// Formats marks output string.
        /// </summary>
        /// <returns>Marks to diplay.</returns>
        public override string ToString() {
            var s = string.Empty;

            foreach (var mark in _items)
                s += mark.ToString() + ", ";

            if (s.Length > 0) {
                s = s.Remove(s.Length - 2, 2);
                _len = s.Length;
            }

            return s;
        }

        #endregion
    }
}
