using DoctorAppointmentAppBLLibrary;
using DoctorAppointmentAppDLLibrary;
using DoctorAppointmentAppModelLibrary;

namespace DoctorAppointmentAppTests
{
    [TestFixture]
    public class AppointmentBLTests
    {
        AppointmentBL _appointmentBL;
        AppointmentRepository _appointmentRepo;

        [SetUp]
        public void Setup()
        {
            _appointmentRepo = new AppointmentRepository();
            _appointmentBL = new AppointmentBL(_appointmentRepo);
        }

        [Test]
        public void ScheduleAppointment_ShouldReturnAppointmentId_WhenAppointmentIsScheduled()
        {
            var appointment = new Appointment { AppointmentId = 1, AppointmentDate = DateTime.Now, Availability = true };
            var result = _appointmentBL.ScheduleAppointment(appointment);

            Assert.AreEqual(appointment.AppointmentId, result);
        }

        [Test]
        public void CancelAppointment_ShouldReturnCancelledAppointment_WhenAppointmentExists()
        {
            var appointment = new Appointment { AppointmentId = 1, AppointmentDate = DateTime.Now, Availability = true };
            _appointmentBL.ScheduleAppointment(appointment);

            var result = _appointmentBL.CancelAppointment(1);

            Assert.AreEqual(appointment, result);
        }

        [Test]
        public void RescheduleAppointment_ShouldReturnUpdatedAppointment_WhenAppointmentExists()
        {
            var appointment = new Appointment { AppointmentId = 1, AppointmentDate = DateTime.Now, Availability = true };
            _appointmentBL.ScheduleAppointment(appointment);

            var result = _appointmentBL.RescheduleAppointment(1);

            Assert.AreEqual(appointment, result);
        }

        [Test]
        public void ScheduleAppointment_ShouldReturnZero_WhenAppointmentIsNotScheduled()
        {
            var appointment = new Appointment { AppointmentId = 0, AppointmentDate = DateTime.Now, Availability = true };
            var result = _appointmentBL.ScheduleAppointment(appointment);

            Assert.AreEqual(0, result);
        }


        [Test]
        public void ScheduleAppointment_ShouldThrowException_WhenAppointmentIsNull()
        {
            Appointment appointment = null;

            Assert.Throws<ArgumentNullException>(() => _appointmentBL.ScheduleAppointment(appointment));
        }

        [Test]
        public void CancelAppointment_ShouldThrowException_WhenAppointmentIdIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => _appointmentBL.CancelAppointment(-1));
        }

        [Test]
        public void RescheduleAppointment_ShouldThrowException_WhenAppointmentIdIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => _appointmentBL.RescheduleAppointment(-1));
        }
    }
}
