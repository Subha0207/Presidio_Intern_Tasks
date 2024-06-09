using DoctorAppointmentAppDLLibrary;
using DoctorAppointmentAppModelLibrary;

namespace DoctorAppointmentAppBLLibrary
{
    public class DoctorBL
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorBL(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }



        public int AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null.");
            }
            var addedDoctor = _doctorRepository.Add(doctor);
            if (addedDoctor == null)
            {
                throw new InvalidOperationException("Failed to add doctor.");
            }
            return addedDoctor.DoctorId;
        }


        public Doctor GetDoctorById(int doctorId)
        {
            return _doctorRepository.Get(doctorId);
        }

        

        public Doctor UpdateDoctorDetails(Doctor doctor)
        {
            var existingDoctor = _doctorRepository.Get(doctor.DoctorId);
            if (existingDoctor == null)
            {
                throw new InvalidOperationException("Doctor does not exist.");
            }
            return _doctorRepository.Update(doctor);
        }


        public bool CheckAvailability(int doctorId, DateTime date)
        {
            var doctor = _doctorRepository.Get(doctorId);
            return doctor != null && doctor.Availability.ContainsKey(date) && doctor.Availability[date];
        }
    }
}
