using DoctorAppointmentAppDLLibrary;
using DoctorAppointmentAppDLLibrary.Model;

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

       

       

        public async Task<Appointment> GetAppointmentById(int AppointmentId)
        {

            Appointment appointment = await _appointmentRepository.Get(AppointmentId);
            if (appointment != null)
            {
                return appointment;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Appointment>> GetAppointmentsForPatient(int PatientId)
        {
            IList<Appointment> appointments = await _appointmentRepository.GetAll();
            IList<Appointment> result = new List<Appointment>();
            if (appointments != null)
            {
                foreach (var appointment in appointments)
                {
                    if (appointment.Patient.PatientId == PatientId)
                    {
                        result.Add(appointment);
                    }
                }
                if (result.Count > 0)
                {
                    return (List<Appointment>)result;
                }
                
            }
            
            throw new NotImplementedException();
        }
    }
}
