using DoctoeClinicAPI.Model;

namespace DoctoeClinicAPI.Interfaces
{
    public interface IDoctorService
    {


        public Task<Doctor> GetDoctorBySpeciality(string speciality);
        public Task<Doctor> UpdateDoctorExperience(int doctorId, float experience);
        public Task<IEnumerable<Doctor>> GetDoctors();
    }
}
