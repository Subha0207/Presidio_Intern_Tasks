
namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class EmployeeUserDTO

    {

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public EmployeeUserDTO(string name,DateTime dateOfBirth,string phone,string image,string role,string password) 
        {
            Name = name;
            DateOfBirth=dateOfBirth;
            Phone = phone;
            Image = image;
            Role = role;
            Password = password;
        }
    }
}