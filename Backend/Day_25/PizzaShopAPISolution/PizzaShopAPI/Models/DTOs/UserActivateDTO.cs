using System.Runtime.InteropServices;

namespace PizzaShopAPI.Models.DTOs
{
    public class UserActivateDTO
    {
        public int UserId;
        public string Status;
        public bool Activation = false;
    }
}

