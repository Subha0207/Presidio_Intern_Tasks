
namespace DoctorAppointmentAppModelLibrary
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public Dictionary<DateTime, bool> Availability { get; set; }

        public Doctor()
        {
            DoctorId = 0;
            Name = string.Empty;
            Specialty = string.Empty;
            Availability = new Dictionary<DateTime, bool>();
        }

        public Doctor(int doctorId, string name, string specialty, Dictionary<DateTime, bool> availability)
        {
            DoctorId = doctorId;
            Name = name;
            Specialty = specialty;
            Availability = availability;
        }
        public static implicit operator Doctor(string v)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Doctor a, Doctor b)
        {
            return a.DoctorId == b.DoctorId;

        }
        public static bool operator !=(Doctor a, Doctor b)
        {
            return a.DoctorId != b.DoctorId;
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

    public class DoctorDictionary
    {
        public Dictionary<int, Doctor> Doctors { get; set; }

        public DoctorDictionary()
        {
            Doctors = new Dictionary<int, Doctor>
            {
                {
                    1,
                    new Doctor(1, "Dr. Smith", "Cardiology", new Dictionary<DateTime, bool>
                    {
                        { new DateTime(2024, 5, 1), true },
                        { new DateTime(2024, 5, 2), false },
                        { new DateTime(2024, 5, 3), true },
                    })
                },
                {
                    2,
                    new Doctor(2, "Dr. Johnson", "Neurology", new Dictionary<DateTime, bool>
                    {
                        { new DateTime(2024, 5, 4), true },
                        { new DateTime(2024, 5, 5), false },
                        { new DateTime(2024, 5, 6), true },
                    })
                },
                {
                    3,
                    new Doctor(3, "Dr. Williams", "Orthopedics", new Dictionary<DateTime, bool>
                    {
                        { new DateTime(2024, 5, 7), true },
                        { new DateTime(2024, 5, 8), false },
                        { new DateTime(2024, 5, 9), true },
                    })
                },
                {
                    4,
                    new Doctor(4, "Dr. Brown", "Pediatrics", new Dictionary<DateTime, bool>
                    {
                        { new DateTime(2024, 5, 10), true },
                        { new DateTime(2024, 5, 11), false },
                        { new DateTime(2024, 5, 12), true },
                    })
                },
                
            };
        }
    }
}
