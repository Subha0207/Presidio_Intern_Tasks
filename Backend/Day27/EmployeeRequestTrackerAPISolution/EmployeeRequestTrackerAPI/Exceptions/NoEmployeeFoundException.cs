namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoEmployeeFoundException : Exception
    {
        public NoEmployeeFoundException()
            : base("No employee found ")
        {
        }
    }
}