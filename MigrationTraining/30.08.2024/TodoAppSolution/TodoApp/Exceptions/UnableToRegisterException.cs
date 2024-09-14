namespace TodoApp.Exceptions
{
    public class UnableToRegisterException : Exception
    {

        public UnableToRegisterException(string? message) : base(message)
        {
        }

        public UnableToRegisterException(string? message, UnableToRegisterException ex) : base(message)
        {

        }
    }
}
