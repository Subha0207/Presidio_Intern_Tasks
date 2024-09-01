namespace TodoApp.Models
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Default constructor
        public RegisterDTO()
        {
        }

        // Constructor with all properties
        public RegisterDTO(string firstName, string lastName, string username, string password)
        {
            
            FirstName = firstName;

            LastName = lastName;
            Username = username;
            Password = password;
        }
    }
}
