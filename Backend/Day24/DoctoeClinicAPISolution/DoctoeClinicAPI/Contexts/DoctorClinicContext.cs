
using DoctoeClinicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctoeClinicAPI.Contexts
{
    public class DoctorClinicContext : DbContext
    {
        public DoctorClinicContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { DoctorId = 101, DoctorName = "Jay", Experience = 5, Speciality = "Eye" },
                new Doctor() { DoctorId = 102, DoctorName = "Subha", Experience = 3, Speciality = "Dental" }
                );
        }
    }
}
