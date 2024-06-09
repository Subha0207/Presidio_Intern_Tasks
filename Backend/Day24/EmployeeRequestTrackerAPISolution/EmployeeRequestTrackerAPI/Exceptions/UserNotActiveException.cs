namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class UserNotActiveException:Exception
    {
        public UserNotActiveException(string v)
            : base("Your account is not activated")
        {
        }
    }
}
