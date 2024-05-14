namespace DoctoeClinicAPI.Exceptions
{
    public class NoSuchDoctorException:Exception
    {
        public NoSuchDoctorException()
            : base("No Doctor exists with given id")
        {
        }
    }
}
