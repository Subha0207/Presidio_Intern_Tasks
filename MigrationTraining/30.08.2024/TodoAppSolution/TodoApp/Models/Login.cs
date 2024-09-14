using System;

namespace TodoApp.Models
{
    /// <summary>
    /// C# model class representing login credentials.
    /// </summary>
    [Serializable]
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }

        // Default constructor
        public Login()
        {
        }

        // Constructor with properties
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
