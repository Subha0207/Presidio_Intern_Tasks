namespace TodoApp.Exceptions
{
    public class UserNotFoundException : Exception
    {

        string msg = string.Empty;

        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            msg = message;
        }
        public override string Message => msg;
    }
}
