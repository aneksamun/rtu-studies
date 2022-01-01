namespace SchoolReport.Client.Common {

    /// <summary>
    /// Describes menu available operations
    /// </summary>
    public enum OperationType {
        /// <summary>
        /// Enter a new student
        /// </summary>
        EnterStudent = 1,

        /// <summary>
        /// View students
        /// </summary>
        ViewStudents = 2,

        /// <summary>
        /// View students by mark criteria 
        /// </summary>
        ViewStudentsByMark = 3,

        /// <summary>
        /// Exit application
        /// </summary>
        Exit = 4
    }
}
