namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoSuchEmployeeException : Exception
    {
        public NoSuchEmployeeException()
            : base("No employee found with the provided phone number.")
        {
        }
    }
}