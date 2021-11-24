using System;
using System.Collections.Generic;
using System.Linq;
using HealthSystem.Common;

namespace HealthSystem.Business {

    public class GetMethods {

        /// <summary>
        /// Gets doctor list
        /// </summary>
        public static IList<Ārsts> GetDoctorsList() {
            using (MapConnection db = new MapConnection()) {
                var doctors = from d in db.Persona.OfType<Ārsts>()
                              orderby d.Specializācija
                              select d;
                
                return doctors.ToList();
            }
        }

        /// <summary>
        /// Gets doctors by lastname
        /// </summary>
        /// <param name="lastname"></param>
        public static IList<Ārsts> GetDoctorsByLastname(string lastname) {
            using (MapConnection db = new MapConnection()) {
                var doctors = from d in db.Persona.OfType<Ārsts>()
                              where d.Uzvārds.StartsWith(lastname)
                              orderby d.Specializācija
                              select d;

                return doctors.ToList();
            }
        }

        /// <summary>
        /// Gets doctor by his ID
        /// </summary>
        /// <param name="personID"></param>
        public static Ārsts GetDoctorByID(int personID) {
            using (MapConnection db = new MapConnection()) {
                var doctor = (from d in db.Persona.OfType<Ārsts>()
                              where d.PersonasID == personID
                              select d).First();

                db.Detach(doctor);
                return doctor;
            }
        }

        /// <summary>
        /// Gets registry staff list
        /// </summary>
        public static IList<Reģ_darb> GetRegistryStaffList() {
            using (MapConnection db = new MapConnection()) {
                var registryStaff = from rd in db.Persona.OfType<Reģ_darb>()
                                    orderby rd.Uzvārds
                                    select rd;

                return registryStaff.ToList();
            }
        }

        /// <summary>
        /// Gets registry staff by lastname
        /// </summary>
        /// <param name="lastname"></param>
        public static IList<Reģ_darb> GetRegistryStaffByLastname(string lastname) {
            using (MapConnection db = new MapConnection()) {
                var registryStaff = from rd in db.Persona.OfType<Reģ_darb>()
                                    where rd.Uzvārds.StartsWith(lastname)
                                    orderby rd.Uzvārds
                                    select rd;

                return registryStaff.ToList();
            }
        }

        /// <summary>
        /// Gets desk clerk by his ID
        /// </summary>
        /// <param name="personID"></param>
        public static Reģ_darb GetDeskClerkByID(int personID) {
            using (MapConnection db = new MapConnection()) {
                var deskClerk = (from rd in db.Persona.OfType<Reģ_darb>()
                                 where rd.PersonasID == personID
                                 select rd).First();

                db.Detach(deskClerk);
                return deskClerk;
            }
        }

        /// <summary>
        /// Gets administrator by his ID
        /// </summary>
        /// <param name="personID"></param>
        public static Administrators GetAdminByID(int personID) {
            using (MapConnection db = new MapConnection()) {
                var admin = (from a in db.Persona.OfType<Administrators>()
                             where a.PersonasID == personID
                             select a).First();

                db.Detach(admin);
                return admin;
            }
        }

        /// <summary>
        /// Gets disease by his ID
        /// </summary>
        /// <param name="diseaseID"></param>
        public static Slimība GetDiseaseByID(int diseaseID) {
            using (MapConnection db = new MapConnection()) {
                var disease = (from d in db.Slimība
                               where d.SlimībasID == diseaseID
                               select d).First();

                db.Detach(disease);
                return disease;
            }
        }

        /// <summary>
        /// Gets disease by title
        /// </summary>
        /// <param name="title"></param>
        public static IList<Slimība> GetDiseaseByTitle(string title) {
            using (MapConnection db = new MapConnection()) {
                var diseases = from d in db.Slimība
                               where d.Diagnoze.Contains(title)
                               orderby d.Diagnoze
                               select d;

                return diseases.ToList();
            }
        }

        /// <summary>
        /// Gets doctors list
        /// </summary>
        public static IList<Slimība> GetDeasesList() {
            using (MapConnection db = new MapConnection()) {
                var diseases = from d in db.Slimība
                               orderby d.Diagnoze
                               select d;

                return diseases.ToList();
            }
        }

        /// <summary>
        /// Gets patients list
        /// </summary>
        public static IList<Pacients> GetPatientsList() {
            using (MapConnection db = new MapConnection()) {
                return db.Persona.OfType<Pacients>()
                    .OrderBy(p => p.Uzvārds).ToList();
            }
        }

        /// <summary>
        /// Gets patients by lastname
        /// </summary>
        /// <param name="lastname"></param>
        public static IList<Pacients> GetPatientsByLastname(string lastname) {
            using (MapConnection db = new MapConnection()) {
                return db.Persona.OfType<Pacients>()
                    .Where(p => p.Uzvārds.StartsWith(lastname))
                    .ToList();
            }
        }

        /// <summary>
        /// Gets patient by ID
        /// </summary>
        /// <param name="patientID"></param>
        public static Pacients GetPatientByID(int patientID) {
            using (MapConnection db = new MapConnection()) {
                var patient = db.Persona.OfType<Pacients>()
                    .First(p => p.PersonasID == patientID);

                db.Detach(patient);
                return patient;
            }
        }

        /// <summary>
        /// Gets patients
        /// </summary>
        public static object GetPatients() {
            using (MapConnection db = new MapConnection()) {
                var patients = from d in db.Persona.OfType<Pacients>()
                               select new { 
                                   PersonID = d.PersonasID, 
                                   Fullname = d.Vārds + " " + d.Uzvārds 
                               };

                var results = patients.ToList()
                    .Concat(new[] { new { PersonID = -1, Fullname = "Lūdzu izvēlēties pacientu" } });

                return results.ToArray();
            }
        }

        /// <summary>
        /// Gets doctors specializations
        /// </summary>
        public static List<string> GetDoctorsSpecializations(string nullableSpecialization) {
            using (MapConnection db = new MapConnection()) {
                IQueryable<string> query = (from d in db.Persona.OfType<Ārsts>()
                                            select d.Specializācija).Distinct();

                List<string> specialization = query.ToList();
                specialization.Add(nullableSpecialization);

                return specialization;
            }
        }

        /// <summary>
        /// Gets associated doctors and patient
        /// </summary>
        public static object GetAssociatedObjects() {
            using (MapConnection db = new MapConnection()) {
                var query = from dp in db.ĀrstsPacients
                            orderby dp.Pacients.Vārds
                            select new {
                                dp.ĀrstaPacientaID,
                                PatientFirstname = dp.Pacients.Vārds,
                                PatientLastname = dp.Pacients.Uzvārds,
                                DoctorFirstname = dp.Ārsts.Vārds,
                                DoctorLastname = dp.Ārsts.Uzvārds
                            };

                return query.ToList();
            }
        }

        /// <summary>
        /// Gets associated objects by patient lastname
        /// </summary>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public static object GetAssociationByLastname(string lastname) {
            using (MapConnection db = new MapConnection()) {
                var query = from dp in db.ĀrstsPacients
                            where dp.Pacients.Uzvārds.StartsWith(lastname)
                            select new {
                                dp.ĀrstaPacientaID,
                                PatientFirstname = dp.Pacients.Vārds,
                                PatientLastname = dp.Pacients.Uzvārds,
                                DoctorFirstname = dp.Ārsts.Vārds,
                                DoctorLastname = dp.Ārsts.Uzvārds
                            };

                return query.ToList();
            }
        }

        /// <summary>
        /// Gets current doctor patients
        /// </summary>
        public static object GetDoctorPatients() {
            using (MapConnection db = new MapConnection()) {
                var patients = from dp in db.ĀrstsPacients
                               where dp.Ārsts.PersonasID == GlobalMembers.GlobalPersonID
                               select new {
                                   PersonID = dp.Pacients.PersonasID, 
                                   Fullname = dp.Pacients.Vārds + " " + dp.Pacients.Uzvārds 
                               };

                var results = patients.ToList()
                    .Concat(new[] { new { PersonID = -1, Fullname = "Lūdzu izvēlēties pacientu" } });

                return results.ToArray();
            }
        }

        /// <summary>
        /// Gets diseases
        /// </summary>
        public static object GetDiseases() {
            using (MapConnection db = new MapConnection()) {
                var query = from d in db.Slimība
                            select new { d.SlimībasID, d.Diagnoze };

                var diseases = query.ToList()
                    .Concat(new[] { new { SlimībasID = -1, Diagnoze = "Lūdzu izvēlēties slimību" } });

                return diseases.ToArray();
            }
        }

        /// <summary>
        /// Gets treatments list for doctor
        /// </summary>
        /// <returns></returns>
        public static object GetDoctorTreatmentsList() {
            using (MapConnection db = new MapConnection()) {
                var query = from t in db.Ārstēšana
                            where t.ĀrstsPacients.Ārsts.PersonasID == GlobalMembers.GlobalPersonID
                            orderby t.Diagnozes_datums descending
                            select new {
                                t.ĀrstēšanasID,
                                PatientFirstname = t.ĀrstsPacients.Pacients.Vārds,
                                PatientLastname = t.ĀrstsPacients.Pacients.Uzvārds,
                                t.Slimība.Diagnoze,
                                t.Diagnozes_datums,
                                t.Atveselošanas_datums,
                                t.Slimības_stāvoklis,
                                t.Terapijas_kurss
                            };

                return query.ToList();
            }
        }

        /// <summary>
        /// Gets treatments list for patient
        /// </summary>
        /// <returns></returns>
        public static object GetPatientTreatmentsList() {
            using (MapConnection db = new MapConnection()) {
                var query = from t in db.Ārstēšana
                            where t.ĀrstsPacients.Pacients.PersonasID == GlobalMembers.GlobalPersonID
                            orderby t.Diagnozes_datums descending
                            select new {
                                t.ĀrstēšanasID,
                                DoctorFirstname = t.ĀrstsPacients.Ārsts.Vārds,
                                DoctorLastname = t.ĀrstsPacients.Ārsts.Uzvārds,
                                t.Slimība.Diagnoze,
                                t.Diagnozes_datums,
                                t.Atveselošanas_datums,
                                t.Slimības_stāvoklis,
                                t.Terapijas_kurss
                            };

                return query.ToList();
            }
        }

        /// <summary>
        /// Gets treatment for doctor by criteria
        /// </summary>
        /// <param name="lastname"></param>
        /// <param name="disease"></param>
        /// <returns></returns>
        public static object GetDoctorTreatmentsByCriteria(string lastname, string disease) {
            using (MapConnection db = new MapConnection()) {
                var query = from t in db.Ārstēšana
                            where t.ĀrstsPacients.Ārsts.PersonasID == GlobalMembers.GlobalPersonID
                            orderby t.Diagnozes_datums descending
                            select new {
                                t.ĀrstēšanasID,
                                PatientFirstname = t.ĀrstsPacients.Pacients.Vārds,
                                PatientLastname = t.ĀrstsPacients.Pacients.Uzvārds,
                                t.Slimība.Diagnoze,
                                t.Diagnozes_datums,
                                t.Atveselošanas_datums,
                                t.Slimības_stāvoklis,
                                t.Terapijas_kurss
                            };

                if (lastname != String.Empty)
                    query = query.Where(t => t.PatientLastname.StartsWith(lastname));

                if (disease != String.Empty)
                    query = query.Where(t => t.Diagnoze.Contains(disease));

                return query.ToList();
            }
        }

        /// <summary>
        /// Gets treatment for patient by criteria
        /// </summary>
        /// <param name="lastname"></param>
        /// <param name="disease"></param>
        /// <returns></returns>
        public static object GetPatientTreatmentsByCriteria(string lastname, string disease) {
            using (MapConnection db = new MapConnection()) {
                var query = from t in db.Ārstēšana
                            where t.ĀrstsPacients.Pacients.PersonasID == GlobalMembers.GlobalPersonID
                            orderby t.Diagnozes_datums descending
                            select new {
                                t.ĀrstēšanasID,
                                DoctorFirstname = t.ĀrstsPacients.Ārsts.Vārds,
                                DoctorLastname = t.ĀrstsPacients.Ārsts.Uzvārds,
                                t.Slimība.Diagnoze,
                                t.Diagnozes_datums,
                                t.Atveselošanas_datums,
                                t.Slimības_stāvoklis,
                                t.Terapijas_kurss
                            };

                if (lastname != String.Empty)
                    query = query.Where(t => t.DoctorLastname.StartsWith(lastname));

                if (disease != String.Empty)
                    query = query.Where(t => t.Diagnoze.Contains(disease));

                return query.ToList();
            }
        }

        /// <summary>
        /// Gets treatment by its ID
        /// </summary>
        /// <param name="personID"></param>
        public static Ārstēšana GetTeatmentByID(int treatmentID, out int patientID, out int diseaseID) {
            using (MapConnection db = new MapConnection()) {
                var treatment = db.Ārstēšana
                    .Include("ĀrstsPacients.Pacients")
                    .Include("Slimība")
                    .First(t => t.ĀrstēšanasID == treatmentID);

                patientID = treatment.ĀrstsPacients.Pacients.PersonasID;
                diseaseID = treatment.Slimība.SlimībasID;

                db.Detach(treatment);
                return treatment;
            }
        }
    }
}
