namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class ReturnUserActivationDTO
    {

        public int Id { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
}
