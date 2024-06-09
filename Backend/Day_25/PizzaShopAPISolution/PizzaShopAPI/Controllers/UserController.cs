using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models.DTOs;
using PizzaShopAPI.Models;
using Microsoft.AspNetCore.Authorization;
using PizzaShopAPI.Exceptions;

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCredentialService _userCredentialService;

        public UserController(IUserCredentialService userCredentialService)
        {
            _userCredentialService = userCredentialService;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userCredentialService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }


        [HttpPost("Register")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult< User>> Register(UserRegisterDTO userDTO)
        {
            try
            {
                User result = await _userCredentialService.Register(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }


        

    }
}
