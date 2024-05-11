using DoctorAppointmentAppDLLibrary;
using DoctorAppointmentAppDLLibrary.Model;
using DoctorAppointmentAppModelLib;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentAppBLLibrary
{
    public class PatientBL : IPatientService
    {
        PatientRepository _patientRepo;

        public PatientBL(PatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }



        public async Task<int> AddPatient(Patient patient)
        {
            var result = await _patientRepo.Add(patient);
            if (result != null)
            {
                return result.PatientId;
            }
            throw new NotImplementedException();
        }

      
        public async Task<Patient> UpdatePatient(Patient patient)
        {
            Patient patient1 = await _patientRepo.Get(patient.PatientId);
            if (patient1 != null)
            {
                return await _patientRepo.Update(patient1);
            }
            throw new NotImplementedException();
        }

        public async Task<Patient> GetPatientById(int PatientId)
        {
            Patient patient = await _patientRepo.Get(PatientId);
            if (patient != null)
            {
                return patient;
            }
            throw new NotImplementedException();
        }
    }
}
