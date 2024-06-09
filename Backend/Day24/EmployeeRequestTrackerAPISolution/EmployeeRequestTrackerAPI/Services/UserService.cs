
using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Repositories;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeRequestTrackerAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Employee> _employeeRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Employee> employeeRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var employee = await _employeeRepo.Get(loginDTO.UserId);
                // if(userDB.Status =="Active")
                //{
                LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(employee);
                return loginReturnDTO;
                // }

                throw new UserNotActiveException("Your account is not activated");
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

        public async Task<ReturnEmployeeDTO> Register(EmployeeUserDTO employeeDTO)
        {
            Employee employee = null;
            User user = null;
            try
            {
                employee = new Employee(employeeDTO.Name, employeeDTO.DateOfBirth, employeeDTO.Phone, employeeDTO.Image, employeeDTO.Role);
                user = MapEmployeeUserDTOToUser(employeeDTO);
                ReturnEmployeeDTO returnEmployee = new ReturnEmployeeDTO();
                employee = await _employeeRepo.Add(employee);
                user.EmployeeId = employee.Id;
                user = await _userRepo.Add(user);
                employeeDTO.Password = string.Empty;

                // Map the EmployeeUserDTO to ReturnEmployeeDTO after the employee is added to the database
                returnEmployee = MapEmployeeUserDTOToEmployee(employeeDTO, employee.Id);

                return returnEmployee;
            }
            catch (Exception) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);
            if (user != null && employee == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private ReturnEmployeeDTO MapEmployeeUserDTOToEmployee(EmployeeUserDTO employeeDTO, int employeeId)
        {
            ReturnEmployeeDTO returnEmployee = new ReturnEmployeeDTO();

            returnEmployee.Name = employeeDTO.Name;
            returnEmployee.DateOfBirth = employeeDTO.DateOfBirth;
            returnEmployee.Phone = employeeDTO.Phone;
            returnEmployee.Role = employeeDTO.Role;
            returnEmployee.Image = employeeDTO.Image;
            returnEmployee.Password = employeeDTO.Password;
            returnEmployee.Id = employeeId; // Include the EmployeeId in the ReturnEmployeeDTO

            return returnEmployee;
        }

        private User MapEmployeeUserDTOToUser(EmployeeUserDTO employeeDTO)
        {
            User user = new User();
          
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return user;
        }

        private LoginReturnDTO MapEmployeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {

            await _employeeRepo.Delete(employee.Id);
        }



        public async Task<ReturnUserActivationDTO> UserActivation(UserActivateDTO userActivateDTO)
        {
            ReturnUserActivationDTO returnUserActivationDTO = null;
            User user = null;
            User result = null;

            try
            {
                user = await _userRepo.Get(userActivateDTO.Id);
                if (user != null)
                {
                    user.Status = userActivateDTO.Status;
                    result = await _userRepo.Update(user);
                    Employee employee = await _employeeRepo.Get(result.EmployeeId);
                    returnUserActivationDTO = MapUserToReturnUserActivationDTO(result, employee);
                }
                else
                {
                    throw new UserNotActiveException("User not found");
                }
            }
            catch (Exception e)
            {
                throw new UserNotActiveException(e.Message);
            }
            return returnUserActivationDTO;
        }

        private ReturnUserActivationDTO MapUserToReturnUserActivationDTO(User result, Employee employee)
        {
            ReturnUserActivationDTO returnUserActivationDTO = new ReturnUserActivationDTO();
            returnUserActivationDTO.Id = result.EmployeeId;
            returnUserActivationDTO.Role = employee.Role;
            returnUserActivationDTO.Status = result.Status;
            return returnUserActivationDTO;
        }

    }
}