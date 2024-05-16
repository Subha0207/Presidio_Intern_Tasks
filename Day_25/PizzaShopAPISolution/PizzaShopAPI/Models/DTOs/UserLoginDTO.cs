namespace PizzaShopAPI.Models.DTOs
{
    public class UserLoginDTO :UserCredential
    {
        public int UserId { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
