using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Interfaces;
using TodoApp.Models;
using TodoApp.Context;
using System.Text.RegularExpressions;
using TodoApp.Exceptions;

namespace TodoApp.Services
{
    public class UserService : IUserService
    {
        private readonly TodoAppContext _context;

        public UserService(TodoAppContext context)
        {
            _context = context;
        }

        public async Task<RegisterReturnDTO> Login(Login login)
        {
            // Fetch the user from the database based on username and password
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

            // If the user is not found, return null or handle it as per your requirement
            if (user == null)
            {
                throw new UnableToLoginException("The username or password is incorrect.");
            }

            // Use the private mapping method to convert User to RegisterReturnDTO
            var registerReturnDTO = MapUserToRegisterReturnDTO(user);

            return registerReturnDTO;
        }

        public async Task<RegisterReturnDTO> Register(RegisterDTO registerDTO)
        {
            // Check if the username is already taken
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == registerDTO.Username);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException("The username is already taken. Please choose a different username.");
            }

            // Validate the password
            if (string.IsNullOrEmpty(registerDTO.Password) || registerDTO.Password.Length < 6 ||
                !Regex.IsMatch(registerDTO.Password, @"[A-Z]") ||
                !Regex.IsMatch(registerDTO.Password, @"[a-z]") ||
                !Regex.IsMatch(registerDTO.Password, @"[0-9]") ||
                !Regex.IsMatch(registerDTO.Password, @"[!@#$%^&*(),.?""{}|<>]"))
            {
                throw new PasswordException("Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
            }

            // Create the new user
            var user = new User
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Username = registerDTO.Username,
                Password = registerDTO.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Map the User to RegisterReturnDTO
            var registerReturnDTO = MapUserToRegisterReturnDTO(user);

            return registerReturnDTO;
        }

        private RegisterReturnDTO MapUserToRegisterReturnDTO(User user)
        {
            return new RegisterReturnDTO
            {
                UserId = user.UserId,
                Username = user.Username
            };
        }



    }
}
