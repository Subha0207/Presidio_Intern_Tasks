using TodoApp.Models;

namespace TodoApp.Interfaces
{
    public interface IUserService
    {
        public Task<RegisterReturnDTO> Login(Login login);


        public Task<RegisterReturnDTO> Register(RegisterDTO registerDTO);
    }
}
