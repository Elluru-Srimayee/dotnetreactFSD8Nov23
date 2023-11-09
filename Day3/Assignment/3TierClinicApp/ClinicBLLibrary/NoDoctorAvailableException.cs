using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NoDoctorAvailableException:Exception
    {
            string message;
            public NoDoctorAvailableException()
            {
                message = "No Doctors are available currently";
            }

            public override string Message => message;
        }
}
