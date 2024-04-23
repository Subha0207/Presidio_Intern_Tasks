using DoctorAppointmentAppDLLibrary;
using DoctorAppointmentAppModelLibrary;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentAppBLLibrary
{
    public class AppointmentBL : IAppointmentService
    {
        private readonly AppointmentRepository _appointmentRepository;

        public AppointmentBL(AppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }


        public int ScheduleAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }
            var result = _appointmentRepository.Add(appointment);
            return result != null ? result.AppointmentId : 0;
        }

        public Appointment CancelAppointment(int AppointmentId)
        {
            if (AppointmentId <= 0)
            {
                throw new ArgumentException("Invalid appointment ID.", nameof(AppointmentId));
            }

            var appointment = _appointmentRepository.Delete(AppointmentId);
            if (appointment == null)
            {
                throw new InvalidOperationException("Appointment not found.");
            }

            return appointment;
        }

        public Appointment RescheduleAppointment(int AppointmentId)
        {
            if (AppointmentId <= 0)
            {
                throw new ArgumentException("Invalid appointment ID.", nameof(AppointmentId));
            }

            var appointment = _appointmentRepository.Get(AppointmentId);
            if (appointment == null)
            {
                throw new InvalidOperationException("Appointment not found.");
            }

            appointment.Availability = false;
            var updatedAppointment = _appointmentRepository.Update(appointment);
            if (updatedAppointment == null)
            {
                throw new InvalidOperationException("Failed to update appointment.");
            }

            return updatedAppointment;
        }
        public Appointment GetAppointmentById(int AppointmentId)
        {
            return _appointmentRepository.Get(AppointmentId);
        }

        public List<Appointment> GetAppointmentsForPatient(int PatientId)
        {
            var allAppointments = _appointmentRepository.GetAll();
            return allAppointments?.FindAll(a => a.Patient?.PatientId == PatientId);
        }

        public List<Appointment> GetAppointmentsForDoctor(int DoctorId)
        {
            var allAppointments = _appointmentRepository.GetAll();
            return allAppointments?.FindAll(a => a.Doctor?.DoctorId == DoctorId);
        }
    }
}
