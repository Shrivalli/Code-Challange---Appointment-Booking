    using System;
    using System.Reflection;
    using System.Linq;
   using NUnit.Framework;

    namespace Appointment_Booking_Application.Unittests
    {
        [TestFixture]
        public class Appointment_BookingTests
        {
            private MethodInfo testingMethod;
            private object SUT;

            [SetUp]
            public void Initialize()
            {
                Assembly assembly = Assembly.Load("Appointment_Booking_Application");
                SUT = assembly.CreateInstance(assembly.GetTypes().Where(type => type.Name == "AppointmentDateVerification").FirstOrDefault()?.FullName,
                    false, BindingFlags.CreateInstance, null, null, null, null);
                testingMethod = SUT.GetType().GetMethod("CheckAppointmentRequestDate");

            }
        [Test]
        public void Check_GetDepartments_Method_Is_Present()
        {
            Assembly assembly = Assembly.Load("Appointment_Booking_Application");
            var allBindings = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            testingMethod = SUT.GetType().GetMethod("GetDepartments");
            Assert.IsNull(testingMethod, "GetDepartments not found");
            if (assembly.GetType("PatientDetail") != null)
            {
                MethodInfo testMethod = assembly.GetType("PatientDetail").GetMethod("GetDepartments", allBindings);
                Assert.IsNull(testMethod, "Method GetDepartments NOT implemented OR check spelling");

            }
        }

        [Test]
            public void Check_GetDoctors_Method_Is_Present()
            {
                Assembly assembly = Assembly.Load("Appointment_Booking_Application");
                var allBindings = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
                testingMethod = SUT.GetType().GetMethod("GetDoctors");
            Assert.IsNull(testingMethod, "GetDoctors not found");
            if (assembly.GetType("PatientDetail") != null)
                {
                    MethodInfo testMethod = assembly.GetType("PatientDetail").GetMethod("GetDoctors", allBindings);
                    Assert.IsNull(testMethod, "Method GetDoctors NOT implemented OR check spelling");

                }
            }



            [Test]
            public void Check_Return_Message_When_Date_Is_Not_A_FutureDate()
            {
                DateTime dateTime = DateTime.Now.AddDays(-1);
                Assert.AreEqual("Appointment Rejected, Date must be a future date!", testingMethod.Invoke(SUT, new object[] { dateTime }));
            }

            [Test]
            public void Check_Return_Message_When_Date_Is_Not_CurrentYear()
            {
                DateTime dateTime = DateTime.Now.AddYears(2);
                Assert.AreEqual("Appointment Rejected, You can book appointment only for the current year!", testingMethod.Invoke(SUT, new object[] { dateTime }));
            }

            [Test]
            public void Check_Return_Message_When_Date_Is_Monday()
            {
                DateTime dateTime = DateTime.Now.AddDays(8 - (int)DateTime.Now.DayOfWeek);
                Assert.AreEqual("Sorry!!! Appointment cannot be given on Monday!", testingMethod.Invoke(SUT, new object[] { dateTime }));
            }

            [Test]
            public void Check_Return_Message_When_Date_Is_Valid()
            {
                DateTime dateTime = DateTime.Now.AddDays(8 - (int)DateTime.Now.DayOfWeek + 2);
                Assert.AreEqual("Appointment Confirmed!", testingMethod.Invoke(SUT, new object[] { dateTime }));
            }
        }

    }


