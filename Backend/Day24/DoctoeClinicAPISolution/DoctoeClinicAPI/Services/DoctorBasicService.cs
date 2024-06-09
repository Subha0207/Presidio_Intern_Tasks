using DoctoeClinicAPI.Exceptions;
using DoctoeClinicAPI.Interfaces;
using DoctoeClinicAPI.Model;
using DoctoeClinicAPI.Repositories;

namespace DoctoeClinicAPI.Services
{
    public class DoctorBasicService : IDoctorService
    {
        private IRepository<int, Doctor> _repository;

        public DoctorBasicService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }
        public async Task<Doctor> GetDoctorBySpeciality(string speciality)
        {
            var doctor = (await _repository.Get()).FirstOrDefault(e => e.Speciality ==speciality );
            if (doctor == null)
                throw new NoSuchDoctorException();
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var employees = await _repository.Get();
            if (employees.Count() == 0)
                throw new NoDoctorFoundException();
            return employees;
        }

        public async  Task<Doctor> UpdateDoctorExperience(int doctorId, float experience)
        {
            var doctor = await _repository.Get(doctorId);
            if (doctor == null)
                throw new NoSuchDoctorException();
            doctor.Experience = experience;
            
            doctor = await _repository.Update(doctor);
            return doctor;

        }
    }
}
