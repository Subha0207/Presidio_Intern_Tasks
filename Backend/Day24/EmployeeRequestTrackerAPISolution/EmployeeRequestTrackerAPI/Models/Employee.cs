﻿namespace EmployeeRequestTrackerAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public ICollection<Request> RequestsRaised { get; set; }

        public ICollection<Request> RequestsClosed { get; set; }

        public Employee( string name, DateTime dateOfBirth, string phone, string image, string role)
        {
            
            Name = name;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Image = image;
            Role = role;
        }
    }
}
