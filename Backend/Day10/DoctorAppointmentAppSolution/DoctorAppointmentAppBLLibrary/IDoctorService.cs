using DoctorAppointmentAppModelLibrary;
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
        int AddDoctor(Doctor doctor);
        /// <summary>
        /// Function to get particular Doctor by ID
        /// </summary>
        /// <param name="DoctorID">DoctorID as (int)</param>
        /// <returns></returns>
        Doctor GetDoctorById(int DoctorID);
        /// <summary>
        /// Function to get all Doctors of particular specialization
        /// </summary>
        /// <param name="specialization">specialization as (string)</param>
        /// <returns></returns>
        Doctor UpdateDoctorDetails(Doctor doctor);
        /// <summary>
        /// Function to check Availability of particular Doctor at required Date and Time
        /// </summary>
        /// <param name="DoctorID">DoctorID as (int)</param>
        /// <param name="date">date as (DateTime)</param>
        /// <returns></returns>
        bool CheckAvailability(int DoctorId, DateTime date);
    }
}
