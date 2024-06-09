using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaShopAPI.Models
{
    public class UserCredential
    {

        [Key]
        public int UserId { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        public string Status { get; set; }
    }
}
