using System.Collections.Generic;

namespace Appointment_Booking_Application
{
    public class PatientDetail //Donot change the class name
    {
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        
        public static List<string> departments = new List<string>();
        public static List<string> GetDepartments()
        {
            departments.Add("1)ENT");
            departments.Add("2)Gyanocologist");
            departments.Add("3)Pediatrician");
            departments.Add("4)GeneralPhysician");
            departments.Add("5)Cardiologist");
            return departments;
        }
        public static List<string> GetDoctors(int option)
        {
            List<string> doctors = new List<string>();
            switch (option)
            {
                case 1:
                    doctors.Add("Dr.Murugadoss MD DLO");
                    doctors.Add("Dr.Kalaivani MD DLO");
                    doctors.Add("Dr.Radha MD DLO");
                    break;
                case 2:
                    doctors.Add("Dr.Bala Abirami MD DGO");
                    doctors.Add("Dr.Ramesh MD DGO");
                    doctors.Add("Dr.Revathi MD DGO");
                    break;
                case 3:
                    doctors.Add("Dr.Amudhan MD DCH");
                    doctors.Add("Dr.Gunaseelan MD DCH");
                    doctors.Add("Dr.Agarwal MD DCH");
                    break;
                case 4:
                    doctors.Add("Dr.Natarajan MD");
                    doctors.Add("Dr.Nanda MD");
                    doctors.Add("Dr.Keerthi MD");
                    break;
                case 5:
                    doctors.Add("Dr.Ashirvatham MD DM");
                    doctors.Add("Dr.Cherian MD DM");
                    doctors.Add("Dr.Ashwath MD DM");
                    break;
                default:
                    System.Console.WriteLine("Choose the correct option!");
                    break;
            }
            return doctors;

        }
    }
}
    

