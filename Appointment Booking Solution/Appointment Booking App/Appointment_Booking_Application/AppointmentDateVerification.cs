using System;

namespace Appointment_Booking_Application
{
    
    public class AppointmentDateVerification//Do not change this classname
    {
        
        public string CheckAppointmentRequestDate(DateTime appointmentRequestDate) // Do not change this method name
        {
            //Validate the date based on the conditions given in the requirement document.
            if (appointmentRequestDate.Date < DateTime.Now.Date)
                return "Appointment Rejected, Date must be a future date!";
            if (appointmentRequestDate.Year != DateTime.Now.Year)
                return "Appointment Rejected, You can book appointment only for the current year!";
            if (appointmentRequestDate.DayOfWeek == DayOfWeek.Monday)
                return "Sorry!!! Appointment cannot be given on Monday!";
            return "Appointment Confirmed!";
        }

        
    }
}
