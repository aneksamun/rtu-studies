using System.Linq;
using HealthSystem.Common;

namespace HealthSystem.Business {

    public class ValidationMethods {
        
        /// <summary>
        /// Validates user by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static bool IsValidPerson(string username, string password) {
            using (MapConnection db = new MapConnection()) {
                var persons = db.CheckPerson(username, password).ToList();

                if (persons.Count != 0) {
                    foreach (var person in persons) {
                        GlobalMembers.GlobalPersonID = person.PersonasID;
                        GlobalMembers.GlobalPersonType = person.Personas_tips;
                    }
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if username is taken by another user
        /// </summary>
        /// <param name="username"></param>
        public static bool UsernameExists(string username) {
            int number;
            using (MapConnection db = new MapConnection()) {
                number = db.Persona
                    .Where(p => p.Lietotājvārds.ToUpper() == username.ToUpper())
                    .Count();
            }

            return number > 0;
        }

        /// <summary>
        /// Checks if patient is already associated to current doctor
        /// </summary>
        /// <returns></returns>
        public static bool IsAssociated(int patientID, int doctorID) {
            using (MapConnection db = new MapConnection()) {
                return (from dp in db.ĀrstsPacients
                        where dp.Ārsts.PersonasID == doctorID &&
                        dp.Pacients.PersonasID == patientID
                        select dp).Count() > 0;
            }
        }
    }
}
