namespace TodoApp.Exceptions
{
    public class PasswordException :Exception
    {
        public PasswordException(string? message) : base(message)
        {
        }

        public PasswordException(string? message, PasswordException ex) : base(message)
        {

        }
    }
}
