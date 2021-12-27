using System;
using System.Linq;
using System.Text;
using System.Data;

namespace HealthSystem.Business {
    
    public class UpdateMethods {

        /// <summary>
        /// Updates person type object
        /// </summary>
        /// <typeparam name="T">Person type object</typeparam>
        /// <param name="person">Person type object</param>
        public static void UpdatePerson<T>(T person) where T : Persona {
            using (MapConnection db = new MapConnection()) {
                db.AttachUpdated(person);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Updates disease instance
        /// </summary>
        public static void UpdateDisease(Slimība disease) {
            using (MapConnection db = new MapConnection()) {
                db.AttachUpdated(disease);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Updates treatment instance
        /// </summary>
        public static void UpdateTreatment(Ārstēšana treatment) {
            using (MapConnection db = new MapConnection()) {
                db.AttachUpdated(treatment);
                db.SaveChanges();
            }
        }
    }
}
