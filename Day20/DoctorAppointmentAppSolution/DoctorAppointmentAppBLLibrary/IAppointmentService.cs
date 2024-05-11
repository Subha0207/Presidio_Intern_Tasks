using DoctorAppointmentAppDLLibrary.Model;
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

       public Task<Appointment> GetAppointmentById(int AppointmentId);
        /// <summary>
        /// Function to Update Appointment Status
        /// </summary>
        /// <param name="AppointmentID">AppointmentID as (int)</param>
        /// <returns></returns>

       public Task<List<Appointment>> GetAppointmentsForPatient(int PatientId);
        /// <summary>
        /// Function to get Appointments allocated to particular Doctor
        /// </summary>
        /// <param name="DoctorID">DoctorID as (int)</param>
        /// <returns></returns>

    }
}
