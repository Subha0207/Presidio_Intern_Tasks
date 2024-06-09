namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoSuchRequestException:Exception
    {
        public NoSuchRequestException() : base("No such request exists"){

        }
    }
}
