using DoctorAppointmentAppDLLibrary;
using DoctorAppointmentAppDLLibrary.Model;


namespace DoctorAppointmentAppBLLibrary
{
    public class DoctorBL:IDoctorService
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorBL(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }



        public async  Task<int> AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null.");
            }
            var addedDoctor = await _doctorRepository.Add(doctor);
            if (addedDoctor == null)
            {
                throw new InvalidOperationException("Failed to add doctor.");
            }
            return addedDoctor.DoctorId;
        }



        public async Task<Doctor> GetDoctorById(int DoctorId)
        {
            Doctor doctor = await _doctorRepository.Get(DoctorId);
            if (doctor != null)
            {
                return doctor;
            }
            throw new NotImplementedException();
        }

        public async Task<Doctor> UpdateDoctorDetails(Doctor doctor)
        {
            Doctor doctor1 = await _doctorRepository.Get(doctor.DoctorId);
            if (doctor1 != null)
            {
                return await _doctorRepository.Update(doctor1);
            }
            throw new NotImplementedException();
        }

        
    }
}
