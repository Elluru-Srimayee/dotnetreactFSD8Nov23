using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NoSuchDoctorException:Exception
    {
        string message;
        public NoSuchDoctorException()
        {
            message = "The Doctor with the given Employee Id is not present";
        }
        public override string Message => message;

    }
}
