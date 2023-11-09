using System.Diagnostics;

namespace ClinicModelLibrary
{
    public class Doctor
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Phone { get; set; }
        public int Experience { get; set; }

        public Doctor(string name, int phone, int experience)
        {
            Name = name;
            Phone = phone;
            Experience = experience;
        }
        public override string ToString()
        {
            return $"Doctor Id : {EmployeeId}\nDoctor Name : {Name}\nDoctor Phone number : {Phone}\nDoctor Experience : {Experience}";
        }
        public Doctor()
        {
        }
    }
}