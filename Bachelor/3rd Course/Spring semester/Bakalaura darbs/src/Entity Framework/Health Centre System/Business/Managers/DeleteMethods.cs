using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HealthSystem.Business {
    
    public class DeleteMethods {

        /// <summary>
        /// Deletes the doctors and thier associations
        /// </summary>
        public static void DeleteDoctor(int personID) {
            using (MapConnection db = new MapConnection()) {

                var doctor = db.Persona
                    .OfType<Ārsts>()
                    .Include("ĀrstsPacients.Ārstēšana")
                    .First(p => p.PersonasID == personID);

                foreach (var doctorPatient in doctor.ĀrstsPacients.ToList()) {
                    foreach (var threatment in doctorPatient.Ārstēšana.ToList()) {
                        doctorPatient.Ārstēšana.Remove(threatment);
                        db.DeleteObject(threatment);
                    }

                    doctor.ĀrstsPacients.Remove(doctorPatient);
                    db.DeleteObject(doctorPatient);
                }

                db.DeleteObject(doctor);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the desk clerk record
        /// </summary>
        public static void DeleteDeskClerk(int personID) {
            using (MapConnection db = new MapConnection()) {

                var deskClerk = db.Persona
                    .OfType<Reģ_darb>()
                    .First(p => p.PersonasID == personID);

                db.DeleteObject(deskClerk);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes disease
        /// </summary>
        public static void DeleteDisease(int diseaseID) {
            using (MapConnection db = new MapConnection()) {
                EntityKey diseaseKey = new EntityKey("MapConnection.Slimība", "SlimībasID", diseaseID);
                var disease = db.GetObjectByKey(diseaseKey);
                db.DeleteObject(disease);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the patients and thier associations
        /// </summary>
        public static void DeletePatient(int personID) {
            using (MapConnection db = new MapConnection()) {

                var patient = db.Persona
                    .OfType<Pacients>()
                    .Include("ĀrstsPacients.Ārstēšana")
                    .First(p => p.PersonasID == personID);

                foreach (var doctorPatient in patient.ĀrstsPacients.ToList()) {
                    foreach (var threatment in doctorPatient.Ārstēšana.ToList()) {
                        doctorPatient.Ārstēšana.Remove(threatment);
                        db.DeleteObject(threatment);
                    }

                    patient.ĀrstsPacients.Remove(doctorPatient);
                    db.DeleteObject(doctorPatient);
                }

                db.DeleteObject(patient);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes associations between doctors and patients
        /// </summary>
        /// <param name="doctorPatientID"></param>
        public static void DeleteAssociation(int doctorPatientID) {
            using (MapConnection db = new MapConnection()) {
                EntityKey doctorPatientKey = new EntityKey("MapConnection.ĀrstsPacients", "ĀrstaPacientaID", doctorPatientID);
                var doctorPatient = db.GetObjectByKey(doctorPatientKey);
                db.DeleteObject(doctorPatient);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes treatment
        /// </summary>
        /// <param name="doctorPatientID"></param>
        public static void DeleteTreatment(int treatmentID) {
            using (MapConnection db = new MapConnection()) {
                EntityKey diseaseKey = new EntityKey("MapConnection.Ārstēšana", "ĀrstēšanasID", treatmentID);
                var disease = db.GetObjectByKey(diseaseKey);
                db.DeleteObject(disease);
                db.SaveChanges();
            }
        }
    }
}