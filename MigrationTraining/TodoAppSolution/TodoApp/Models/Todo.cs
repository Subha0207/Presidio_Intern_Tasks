using System;

namespace TodoApp.Models
{
    /// <summary>
    /// Todo.cs
    /// This is a model class that represents a Todo entity.
    /// </summary>
    public class Todo
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public bool Status { get; set; } = false;
        public int UserId { get; set; }
        public string UserName { get; set; }

        // Navigation property
        public User User { get; set; }

        // Default constructor
        public Todo()
        {
        }

        // Constructor with all properties
        public Todo(int id, string title, string userName, string description, DateTime targetDate, bool status, int userId)
        {
            TodoId = id;
            Title = title;
            Description = description;
            TargetDate = targetDate;
            Status = status;
            UserId = userId;
            UserName = userName;
        }

        

        
    }
}
