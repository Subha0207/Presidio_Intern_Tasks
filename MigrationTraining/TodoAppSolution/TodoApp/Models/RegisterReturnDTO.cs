public class RegisterReturnDTO
{
    public int UserId { get; set; }
    public string Username { get; set; }

    // Default constructor
    public RegisterReturnDTO() { }

    // Constructor with properties
    public RegisterReturnDTO(int userId, string username)
    {
        UserId = userId;
        Username = username;
    }
}
