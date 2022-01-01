using System.Collections.Generic;
using System.Linq;

namespace SchoolReport.BO {
    /// <summary>
    /// Encapsulates logic for casting
    /// </summary>
    public static class CastExtensions {

        /// <summary>
        /// Casts IEnumerable source to students.   
        /// </summary>
        /// <param name="source">Source to cast.</param>
        /// <returns>Students.</returns>
        public static Students ToStudents(this IEnumerable<Student> source) {
            return new Students(source.ToList());
        }
    }
}
