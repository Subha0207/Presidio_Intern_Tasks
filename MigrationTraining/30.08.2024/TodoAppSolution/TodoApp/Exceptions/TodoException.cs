namespace TodoApp.Exceptions
{
    public class TodoException : Exception
    {
        string msg = string.Empty;

        public TodoException(string? message) : base(message)
        {
        }

        public TodoException(string message, Exception innerException) : base(message, innerException)
        {
            msg = message;
        }
        public override string Message => msg;
    }
}
