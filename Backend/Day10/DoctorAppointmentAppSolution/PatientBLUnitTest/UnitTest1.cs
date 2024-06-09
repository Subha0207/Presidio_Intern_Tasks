using NUnit.Framework;
using DoctorAppointmentAppModelLibrary;
using DoctorAppointmentAppBLLibrary;
using DoctorAppointmentAppDLLibrary;
using System.Collections.Generic;

namespace DoctorAppointmentAppTests
{
    [TestFixture]
    public class PatientBLTests
    {
        PatientBL _patientBL;
         PatientRepository _patientRepo;

        [SetUp]
        public void Setup()
        {
            _patientRepo = new PatientRepository();
            _patientBL = new PatientBL(_patientRepo);
        }

        [Test]
        public void AddPatient_ShouldReturnPatientId_WhenPatientIsAdded()
        {
            var patient = new Patient { PatientId = 1, Name = "Test Patient" };
            var result = _patientBL.AddPatient(patient);

            Assert.AreEqual(patient.PatientId, result);
        }

        [Test]
        public void GetPatientById_ShouldReturnPatient_WhenPatientExists()
        {
            var patient = new Patient { PatientId = 1, Name = "Test Patient" };
            _patientBL.AddPatient(patient);

            var result = _patientBL.GetPatientById(1);

            Assert.AreEqual(patient, result);
        }

        [Test]
        public void UpdatePatient_ShouldReturnUpdatedPatient_WhenPatientExists()
        {
            var patient = new Patient { PatientId = 1, Name = "Test Patient" };
            _patientBL.AddPatient(patient);

            patient.Name = "Updated Patient";
            var result = _patientBL.UpdatePatient(patient);

            Assert.AreEqual(patient, result);
        }
        
        [Test]
        public void AddPatient_ShouldReturnZero_WhenPatientIsNotAdded()
        {
            var patient = new Patient { PatientId = 0, Name = "Test Patient" };
            var result = _patientBL.AddPatient(patient);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetPatientById_ShouldReturnNull_WhenPatientDoesNotExist()
        {
            var result = _patientBL.GetPatientById(999);

            Assert.IsNull(result);
        }

        

        [Test]
        public void UpdatePatient_ShouldReturnNull_WhenPatientDoesNotExist()
        {
            var patient = new Patient { PatientId = 999, Name = "Nonexistent Patient" };
            var result = _patientBL.UpdatePatient(patient);

            Assert.IsNull(result);
        }

    }
}
