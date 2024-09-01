namespace TodoApp.Exceptions
{
    public class UnableToLoginException : Exception
    {
        public UnableToLoginException(string? message) : base(message)
        {
        }

        public UnableToLoginException(string? message, UnableToLoginException ex) : base(message)
        {

        }
    }
}
