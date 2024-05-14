namespace DoctoeClinicAPI.Exceptions
{
    public class NoDoctorFoundException:Exception
    {
        public NoDoctorFoundException()
            : base("No Doctor found")
        {
        }
    }
}
