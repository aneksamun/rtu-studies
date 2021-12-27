using System.Linq;
using HealthSystem.Common;

namespace HealthSystem.Business {

    public class AddMethods {

        /// <summary>
        /// Adds person type to the context and database
        /// </summary>
        /// <typeparam name="T">Person type object</typeparam>
        /// <param name="person">Person type object</param>
        public static void AddPerson<T>(T person) where T : Persona {
            using (MapConnection db = new MapConnection()) {
                db.AddToPersona(person);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Adds disease to the context and to database
        /// </summary>
        /// <param name="doctor"></param>
        public static void AddDisease(Slimība disease) {
            using (MapConnection db = new MapConnection()) {
                db.AddToSlimība(disease);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Adds association between patients and doctors objects
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="doctorID"></param>
        public static void AddAssociation(int patientID, int doctorID) {
            using (MapConnection db = new MapConnection()) {
                ĀrstsPacients dp = new ĀrstsPacients();
                dp.Pacients = db.Persona.OfType<Pacients>().First(p => p.PersonasID == patientID);
                dp.Ārsts = db.Persona.OfType<Ārsts>().First(d => d.PersonasID == doctorID);
                db.AddToĀrstsPacients(dp);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Adds treatments
        /// </summary>
        /// <param name="treatment"></param>
        public static void AddTreatment(Ārstēšana treatment, int diseaseID, int patientID) {
            using (MapConnection db = new MapConnection()) {
                treatment.Slimība = db.Slimība.First(d => d.SlimībasID == diseaseID);
                treatment.ĀrstsPacients = (from dp in db.ĀrstsPacients
                                           where dp.Ārsts.PersonasID == GlobalMembers.GlobalPersonID &&
                                           dp.Pacients.PersonasID == patientID
                                           select dp).First();
                db.AddToĀrstēšana(treatment);
                db.SaveChanges();
            }
        }
    }
}
