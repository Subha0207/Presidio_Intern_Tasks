using PizzaShopAPI.Models.DTOs;
using PizzaShopAPI.Models;
using PizzaShopAPI.Repositories;
using System.Security.Cryptography;
using System.Text;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Exceptions;

namespace PizzaShopAPI.Services
{
    public class UserCredentialService : IUserCredentialService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, UserCredential> _userCredentialRepo;

        public UserCredentialService(IRepository<int, UserCredential> userCredentialRepo, IRepository<int, User> userRepo)
        {
            _userRepo = userRepo;
            _userCredentialRepo = userCredentialRepo;
        }

        public async Task<User> Login(UserLoginDTO loginDTO)
        {
            var userCredentialDB = await _userCredentialRepo.Get(loginDTO.UserId);
            if (userCredentialDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userCredentialDB.PasswordHashKey);

            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userCredentialDB.Password);

            if (isPasswordSame)
            {
                var user = await _userRepo.Get(loginDTO.UserId);
                if (userCredentialDB.Status == "Active")
                    return user;
                throw new UserNotActiveException("User not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");


        }
        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<User> Register(UserRegisterDTO registerDTO)
        {

            User user = null;
            UserCredential userCredential = null;
            try
            {
                user = registerDTO;
                userCredential = MapUserRegisterDTOToUserCredential(registerDTO);
                user = await _userRepo.Add(user);
                userCredential.UserId = user.UserId;
                userCredential = await _userCredentialRepo.Add(userCredential);
                ((UserRegisterDTO)user).Password = string.Empty;
                return user;
            }
            catch (Exception) { }
            if (user != null)
                await RevertEmployeeInsert(user);
            if (userCredential != null && user == null)
                await RevertUserInsert(userCredential);
            throw new UnableToRegisterException("Not able to register at this moment");

        }
        private async Task RevertUserInsert(UserCredential userCredential)
        {
            await _userCredentialRepo.Delete(userCredential.UserId);
        }

        private async Task RevertEmployeeInsert(User user)
        {
            await _userRepo.Delete(user.UserId);
        }
        private UserCredential MapUserRegisterDTOToUserCredential(UserRegisterDTO registerDTO)
        {

            UserCredential userCredential = new UserCredential();
            userCredential.UserId = registerDTO.UserId;
            userCredential.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            userCredential.PasswordHashKey = hMACSHA.Key;
            userCredential.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            return userCredential;
        }
    }
    }
