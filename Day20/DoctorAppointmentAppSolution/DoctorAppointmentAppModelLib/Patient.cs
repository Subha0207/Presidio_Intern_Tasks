using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentAppModelLib
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; } = string.Empty;

        public Patient()
        {
            PatientId = 0;
            Name = string.Empty;
        }

        public Patient(int patientId, string name)
        {
            PatientId = patientId;
            Name = name;
        }

    }
}
