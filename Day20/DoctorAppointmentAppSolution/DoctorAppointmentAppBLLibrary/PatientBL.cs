using DoctorAppointmentAppDLLibrary;
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

        public int AddPatient(Patient patient)
        {
            var addedPatient = _patientRepo.Add(patient);
            return addedPatient != null ? addedPatient.PatientId : 0;
        }

        public Patient GetPatientById(int PatientId)
        {
            return _patientRepo.Get(PatientId);
        }

        

        public Patient UpdatePatient(Patient patient)
        {
            return _patientRepo.Update(patient);
        }

        
    }
}
