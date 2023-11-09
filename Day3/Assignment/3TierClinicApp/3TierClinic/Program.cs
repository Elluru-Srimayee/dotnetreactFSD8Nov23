using ClinicModelLibrary;
using ClinicBLLibrary;
using ClinicDALLibrary;

namespace ShoppingApp
{
    internal class Program
    {
        IDoctorService doctorService;
        public Program()
        {
            doctorService = new DoctorService();
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Update Number");
            Console.WriteLine("3. Delete Doctor");
            Console.WriteLine("4. Print All Doctor");
            Console.WriteLine("0. Exit");
        }
        void StartAdminActivities()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        UpdateNumber();
                        break;
                    case 3:
                        DeleteDoctor();
                        break;
                    case 4:
                        PrintAllDoctors();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        public void PrintAllDoctors()
        {
            Console.WriteLine("***********************************");
            var doctors = doctorService.GetDoctors();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        void AddDoctor()
        {
            try
            {
                Doctor doctor = TakeDoctorDetails();
                var result = doctorService.AddDoctor(doctor);
                if (result != null)
                {
                    Console.WriteLine("Doctor added");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        Doctor TakeDoctorDetails()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Please enter the doctor name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter the doctor phone number");
            doctor.Phone = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the doctor Experience");
            doctor.Experience = Convert.ToInt32(Console.ReadLine());
            return doctor;
        }
        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the doctor id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteDoctor()
        {
            try
            {
                int id = GetDoctorIdFromUser();
                if (doctorService.Delete(id) != null)
                    Console.WriteLine("Doctor deleted");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdateNumber()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new number");
            int number = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Phone = number;
            doctor.EmployeeId = id;
            try
            {
                var result = doctorService.UpdateDoctorMobile(id, number);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static int Main(string[] args)
        {
            Program program = new Program();
            program.StartAdminActivities();
            Console.WriteLine("Hello, World!");
            return 0;
        }
    }
}

