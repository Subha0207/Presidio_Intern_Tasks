using System;
using System.Collections.Generic;

namespace DoctorAppointmentAppDLLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
