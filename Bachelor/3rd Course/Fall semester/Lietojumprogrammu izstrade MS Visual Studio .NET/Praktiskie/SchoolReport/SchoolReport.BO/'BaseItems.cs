using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolReport.BO {
    /// <summary>
    /// Interacts logic for the base items collection.
    /// </summary>
    [Serializable]
    public class BaseItems<T> : IEnumerable<T> {

        #region [ private members ]

        protected readonly IList<T> _items;

        #endregion

        #region [ properties ]

        /// <summary>
        /// Gets the number of the items contained in collection.
        /// </summary>
        public int Count {
            get { return _items.Count; }
        }

        #endregion

        #region [ ctors ]

        public BaseItems() : this(new List<T>()) { }

        public BaseItems(IList<T> items) {
            _items = items;
        }

        #endregion

        #region [ IEnumerable<T> members ]

        public IEnumerator<T> GetEnumerator() {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _items.GetEnumerator();
        }

        #endregion

        #region [ public members ]

        public void Add(T item) {
            _items.Add(item);
        }

        #endregion
    }
}