
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
          }

}
