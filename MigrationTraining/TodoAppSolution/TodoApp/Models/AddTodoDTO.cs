using System;

namespace TodoApp.Models
{
    /// <summary>
    /// AddTodoDto.cs
    /// This is a DTO (Data Transfer Object) class that represents a structure for adding a Todo entity.
    /// </summary>
    public class AddTodoDTO
    {
        public string Title { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }


        // Default constructor
        protected AddTodoDTO()
        {
        }

        // Constructor with all properties except IDs
        public AddTodoDTO(string title, int userId, string description, DateTime targetDate)
        {
            Title = title;
            UserId = userId;
            Description = description;
            TargetDate = targetDate;
        }
    }
}
