using System;
using System.Collections.Generic;

namespace TodoApp.Models
{
    /// <summary>
    /// C# model class representing a User entity.
    /// </summary>
    [Serializable]
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Navigation property for the one-to-many relationship with Todo
        public ICollection<Todo> Todos { get; set; }

        // Default constructor
        public User()
        {
            Todos = new HashSet<Todo>(); // Initialize the collection to prevent null reference exceptions
        }

        // Constructor with all properties
        public User(string firstName, string lastName, string username, string password, int userId)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Todos = new HashSet<Todo>(); // Initialize the collection
        }
    }
}
