namespace TodoApp.Exceptions
{
    public class TodoNotFoundException : Exception
    {
        public TodoNotFoundException(string? message) : base(message)
        {
        }

        public TodoNotFoundException(string? message, PasswordException ex) : base(message)
        {

        }
    }
}
