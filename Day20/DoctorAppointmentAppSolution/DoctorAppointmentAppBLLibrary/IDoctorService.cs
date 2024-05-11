using DoctorAppointmentAppDLLibrary.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentAppBLLibrary
{
    public interface IDoctorService
    {
        /// <summary>
        /// Function to add doctor
        /// </summary>
        /// <param name="doctor">doctor as (object of Doctor)</param>
        /// <returns></returns>
         Task <int> AddDoctor(Doctor doctor);
        /// <summary>
        /// Function to get particular Doctor by ID
        /// </summary>
        /// <param name="DoctorID">DoctorID as (int)</param>
        /// <returns></returns>
        Task <Doctor> GetDoctorById(int DoctorID);
        /// <summary>
        /// Function to get all Doctors of particular specialization
        /// </summary>
        /// <param name="specialization">specialization as (string)</param>
        /// <returns></returns>
         Task<Doctor> UpdateDoctorDetails(Doctor doctor);
        
    }
}
