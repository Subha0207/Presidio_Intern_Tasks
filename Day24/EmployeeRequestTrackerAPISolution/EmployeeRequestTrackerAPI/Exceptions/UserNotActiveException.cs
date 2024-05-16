namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class UserNotActiveException:Exception
    {
        public UserNotActiveException()
            : base("Your account is not activated")
        {
        }
    }
}
