namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class UnableToActivateUserException : Exception
    {
        public UnableToActivateUserException(string msg) : base(msg) { }

        public UnableToActivateUserException(string msg, string message) : base(msg + " " + message) { }

        public UnableToActivateUserException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
