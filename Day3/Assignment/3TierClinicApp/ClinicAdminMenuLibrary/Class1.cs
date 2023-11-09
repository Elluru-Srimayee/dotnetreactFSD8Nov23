namespace ClinicMenuLibrary
{
    class Doctor
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Experience { get; set; }
        public List<string> Specifications { get; set; }

        public Doctor(string name, string phone, string experience)
        {
            Name = name;
            Phone = phone;
            Experience = experience;
            Specifications = new List<string>();
        }

        public void AddSpecification(string specification)
        {
            Specifications.Add(specification);
        }
    }

    class Appointment
    {
        public Doctor Doctor { get; set; }
        public string PatientName { get; set; }

        public Appointment(Doctor doctor, string patientName)
        {
            Doctor = doctor;
            PatientName = patientName;
        }
    }
}