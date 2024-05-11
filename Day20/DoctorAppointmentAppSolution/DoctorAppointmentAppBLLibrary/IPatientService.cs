using DoctorAppointmentAppDLLibrary.Model;
using DoctorAppointmentAppModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentAppBLLibrary
{
    public interface IPatientService
    {
        /// <summary>
        /// Function to add patient
        /// </summary>
        /// <param name="patient">patient as (object of patient)</param>
        /// <returns></returns>
      public  Task< int> AddPatient(Patient patient);
        /// <summary>
        /// Function to get particular Patient by Id
        /// </summary>
        /// <param name="PatientID">PatientID as (int)</param>
        /// <returns></returns>
       public Task< Patient> GetPatientById(int PatientId);
        /// <summary>
        /// Function to Update Patient Details
        /// </summary>
        /// <param name="patient">patient as (object of patient)</param>
        /// <returns></returns>
       public Task< Patient> UpdatePatient(Patient patient);


    }
}
