using DoctoeClinicAPI.Contexts;
using DoctoeClinicAPI.Exceptions;
using DoctoeClinicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctoeClinicAPI.Repositories
{


    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly DoctorClinicContext _context;
        public DoctorRepository(DoctorClinicContext context)
        {
            _context = context;
        }


        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Task<Doctor> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> Get(int key)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(e => e.DoctorId == key);
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;

        }


        public async Task<Doctor> Update(Doctor item)
        {
            var doctor = await Get(item.DoctorId);
            if (doctor != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return doctor;

            }

            throw new NoSuchDoctorException();
        }


        
    }
}
