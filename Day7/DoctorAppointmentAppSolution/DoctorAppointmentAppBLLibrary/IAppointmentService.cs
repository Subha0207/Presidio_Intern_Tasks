using DoctorAppointmentAppModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentAppBLLibrary
{
    public interface IAppointmentService
    {

        /// <summary>
        /// Function to schedule Appointment
        /// </summary>
        /// <param name="appointment">appointment as (object of Appointment)</param>
        /// <returns></returns>
        int ScheduleAppointment(Appointment appointment);
        /// <summary>
        /// Function to Cancel Appointment
        /// </summary>
        /// <param name="AppointmentID">AppointmentID as (int)</param>
        /// <returns></returns>
        Appointment CancelAppointment(int AppointmentId);
        /// <summary>
        /// Function to Reschedule Appointment
        /// </summary>
        /// <param name="AppointmentID">AppointmentID as (int)</param>
        /// <returns></returns>
        Appointment RescheduleAppointment(int AppointmentId);
        /// <summary>
        /// Get particular Appointment By Id
        /// </summary>
        /// <param name="AppointmentID">AppointmentID as (int)</param>
        /// <returns></returns>
        Appointment GetAppointmentById(int AppointmentId);
        /// <summary>
        /// Function to Update Appointment Status
        /// </summary>
        /// <param name="AppointmentID">AppointmentID as (int)</param>
        /// <returns></returns>

        List<Appointment> GetAppointmentsForPatient(int PatientId);
        /// <summary>
        /// Function to get Appointments allocated to particular Doctor
        /// </summary>
        /// <param name="DoctorID">DoctorID as (int)</param>
        /// <returns></returns>

    }
}
