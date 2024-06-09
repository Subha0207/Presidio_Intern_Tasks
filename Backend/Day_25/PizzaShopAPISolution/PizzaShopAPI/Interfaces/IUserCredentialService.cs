using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface IUserCredentialService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<User> Register(UserRegisterDTO registerDTO);

    }
}
