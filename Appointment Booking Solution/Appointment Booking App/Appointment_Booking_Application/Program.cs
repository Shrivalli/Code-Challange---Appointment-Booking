using System;
using System.Collections.Generic;


namespace Appointment_Booking_Application
{
    
    public class Program //Do not change the class name
    {
        
        //Get the inputs from the user, pass it to the AppointmentDateVerification class
        // and display the output as per the requirement document.
        public static void Main(string[] args)
        {
            try
            {
                PatientDetail patientDetail = new PatientDetail();
                string doctorname;
                Console.WriteLine("Enter patient Name: ");
                patientDetail.PatientName = Console.ReadLine();
                Console.WriteLine("Enter patient Age: ");
                patientDetail.PatientAge = Convert.ToInt32(Console.ReadLine());
                var departments = PatientDetail.GetDepartments();
                Console.WriteLine("Choose the department from the Below list: (1-5) ");
                foreach (var item in departments)
                {
                    Console.WriteLine(item);
                }

                int option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Name of the doctor from the below list with whom you wish to book an Appointment: ");
               
                List<string> doctors = PatientDetail.GetDoctors(option);
                foreach (var item in doctors)
                {
                    Console.WriteLine(item);
                }
                doctorname = Console.ReadLine();

                label: Console.WriteLine("Enter Appointment Request Date: ");
                DateTime appointmentRequestDate = Convert.ToDateTime(Console.ReadLine());

                AppointmentDateVerification appointmentDateVerification = new AppointmentDateVerification();
                string appointmentMessage = appointmentDateVerification.CheckAppointmentRequestDate(appointmentRequestDate);

                Console.WriteLine("----------");
                Console.WriteLine(appointmentMessage);
                if (appointmentMessage == "Appointment Confirmed!")
                {
                    System.Random random = new Random();
                    Console.WriteLine("Patient Id - " + random.Next());
                    Console.WriteLine($"Please Contact {doctorname} on {appointmentRequestDate.Date.ToShortDateString()}");
                }
                else
                {
                    goto label;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------");
            Console.ReadLine();
        }
    }
}
