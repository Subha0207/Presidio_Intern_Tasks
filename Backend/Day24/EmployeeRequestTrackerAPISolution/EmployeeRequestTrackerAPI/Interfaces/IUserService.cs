using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<ReturnEmployeeDTO> Register(EmployeeUserDTO employeeDTO);

        public Task<ReturnUserActivationDTO> UserActivation(UserActivateDTO userActivateDTO);
    }
}