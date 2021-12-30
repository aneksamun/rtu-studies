using System.Collections.Generic;
using System.Linq;

namespace CourseSystem.Bussines {
    public static class GetMethods {
        /// <summary>
        /// Returns course list
        /// </summary>
        public static IList<Course> GetCourses() {
            using (DBDataContext db = new DBDataContext()) {
                var courses = db.Courses.OrderByDescending(c => c.EndTime);
                return courses.ToList();
            }
        }

        /// <summary>
        /// Gets course by course id
        /// </summary>
        /// <param name="couseId"></param>
        public static Course GetCourseByID(int couseId) {
            using (DBDataContext db = new DBDataContext()) {
                return db.Courses
                    .Where(c => c.CourseID == couseId)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Indicates does that person is already participated
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="phoneNum"></param>
        /// <returns></returns>
        public static bool IsParticipated(int courseID,
            string firstname, string lastname, string phoneNum) {

            using (DBDataContext db = new DBDataContext()) {
                var participant = (from p in db.Participants
                                   where p.CourseID == courseID &&
                                         p.Firstname == firstname &&
                                         p.Lastname == lastname &&
                                         p.PhoneNumber == int.Parse(phoneNum)
                                   select p).FirstOrDefault();

                return participant != null;
            }
        }

        /// <summary>
        /// Gets courses titles
        /// </summary>
        /// <returns></returns>
        public static object GetCoursesTitles() {
            using (DBDataContext db = new DBDataContext()) {
                var coursesTitles = from c in db.Courses
                                    orderby c.Title
                                    select new {
                                        c.CourseID,
                                        c.Title
                                    };

                return coursesTitles.ToList();
            }
        }
    }
}
