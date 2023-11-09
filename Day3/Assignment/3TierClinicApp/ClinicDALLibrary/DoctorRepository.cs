using System.Numerics;
using ClinicModelLibrary;
namespace ClinicDALLibrary
{
    public class DoctorRepository:IRepository
    {
        Dictionary<int, Doctor> doctors = new Dictionary<int, Doctor>();
        int GetNextId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors.Keys.Max();
            return ++id;
        }
        /// <summary>
        /// Adds the given doctor to the dictionary 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns>The doctor that has been added</returns>
        public Doctor Add(Doctor doctor)
        {
            int id = GetNextId();
            try
            {
                doctor.EmployeeId = id;
                doctors.Add(doctor.EmployeeId, doctor);
                return doctor;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("The Procuct Id already exists");
                Console.WriteLine(e.Message);
            }
            return null;
        }
        /// <summary>
        /// Deletes the doctor record from the dictionary using the id as key.
        /// </summary>
        /// <param The id of the doctor to be deleted></param>
        /// <returns>The doctor is deleted.</returns>
        public Doctor Delete(int id)
        {
            var doctor = doctors[id];
            doctors.Remove(id);
            return doctor;
        }

        /// <summary>
        /// gets all the values presetn in the dictionary in the form of list.
        /// </summary>
        /// <returns>The list of values in the dictionary.</returns>
        public List<Doctor> GetAll()
        {
            var doctorList = doctors.Values.ToList();
            return doctorList;
        }
        /// <summary>
        /// gets the values of keys in dictionary by using the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The name of the doctor with respective EmployeeId</returns>
        public Doctor GetById(int id)
        {
            return doctors[id];
        }
        /// <summary>
        /// Updates the values in the dictionary using the Employee Id.
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns>The value of the object passed.</returns>
        public Doctor Update(Doctor doctor)
        {
            doctors[doctor.EmployeeId] = doctor;
            return doctors[doctor.EmployeeId];
        }
    }
}