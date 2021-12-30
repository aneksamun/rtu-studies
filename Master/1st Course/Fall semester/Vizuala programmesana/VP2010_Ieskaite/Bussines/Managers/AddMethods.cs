using System;

namespace CourseSystem.Bussines {
    public static class AddMethods {

        /// <summary>
        /// Attaches course obj to persistance context
        /// </summary>
        /// <param name="course">
        /// </param>
        public static void AddCourse(Course course) {
            using (DBDataContext db = new DBDataContext()) {
                db.Courses.InsertOnSubmit(course);
                db.SubmitChanges();
            }
        }

        /// <summary>
        /// Attaches participant obj to persistance context
        /// </summary>
        /// <param name="participant">
        /// </param>
        public static void AddParticipant(Participant participant) {
            using (DBDataContext db = new DBDataContext()) {
                db.Participants.InsertOnSubmit(participant);
                db.SubmitChanges();
            }
        }
    }
}
