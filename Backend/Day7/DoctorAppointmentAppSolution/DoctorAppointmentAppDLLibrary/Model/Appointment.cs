using System;
using System.Collections.Generic;

namespace DoctorAppointmentAppDLLibrary.Model
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public bool? Availability { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
