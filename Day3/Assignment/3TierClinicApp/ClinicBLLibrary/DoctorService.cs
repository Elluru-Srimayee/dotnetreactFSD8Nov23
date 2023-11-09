using ClinicModelLibrary;
using ClinicDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBLLibrary
{
    public class DoctorService : IDoctorService
    {
        IRepository repository;
        public DoctorService()
        {
            repository = new DoctorRepository();
        }
        /// <summary>
        /// Adds the doctor to the collection using the repository
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        /// <exception cref="NotAddedException">Employee Id duplicated</exception>
        public Doctor AddDoctor(Doctor doctor)
        {
            var result = repository.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
        }

        public Doctor Delete(int doctorId)
        {
            var doctor = GetDoctor(doctorId);
            if(doctor!=null)
            {
                repository.Delete(doctorId);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }
        /// <summary>
        /// Returns the product for the given Id
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        /// <exception cref="NoSuchDoctorException"></exception>
        public Doctor GetDoctor(int doctorId)
        {
            var result = repository.GetById(doctorId);
            return result == null ? throw new NoSuchDoctorException():result;
        }

        public Doctor UpdateDoctorExperience(int doctorId, int experience)
        {
            var doctor = GetDoctor(doctorId);
            if(doctor!=null)
            {
                doctor.Experience = Convert.ToInt32(experience);
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }
        public List<Doctor> GetDoctors()
        {
            var doctors = repository.GetAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorAvailableException();
        }

        public Doctor UpdateDoctorMobile(int doctorId, int phone)
        {
            var doctor = GetDoctor(doctorId);
            if (doctor != null)
            {
                doctor.Phone = Convert.ToInt32(phone);
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }
    }
}
