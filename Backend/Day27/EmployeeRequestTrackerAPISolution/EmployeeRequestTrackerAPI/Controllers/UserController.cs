using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(IUserService userService,ILogger<UserController>logger)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO userLoginDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.Login(userLoginDTO);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("User not authenticated");
                    return Unauthorized(new ErrorModel(401, ex.Message));
                }
            }
            return BadRequest("All details are not provided. Please check teh object");
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(ReturnEmployeeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReturnEmployeeDTO>> Register(EmployeeUserDTO userDTO)
        {
            try
            {
                ReturnEmployeeDTO result = await _userService.Register(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
 
    }
}
