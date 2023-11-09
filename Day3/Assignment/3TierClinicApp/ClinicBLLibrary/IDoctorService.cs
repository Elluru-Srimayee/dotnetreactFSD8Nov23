using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;

namespace ClinicBLLibrary
{
    public interface IDoctorService
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor UpdateDoctorMobile(int doctorId, int phone);
        public Doctor GetDoctor(int doctorId);
        public List<Doctor> GetDoctors();
        public Doctor UpdateDoctorExperience(int  doctorId, int experience);
        public Doctor Delete(int  doctorId);
    }
}
