using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentAppModelLibrary
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

        public static implicit operator Patient(string v)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Patient a, Patient b)
        {
            return a.PatientId == b.PatientId;

        }
        public static bool operator !=(Patient a, Patient b)
        {
            return a.PatientId != b.PatientId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }
}

