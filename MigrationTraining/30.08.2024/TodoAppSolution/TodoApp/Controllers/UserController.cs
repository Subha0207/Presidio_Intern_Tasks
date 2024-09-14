using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using TodoApp.Exceptions;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(RegisterReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterReturnDTO>> Register(RegisterDTO registerDTO)
        {
            try
            {
                RegisterReturnDTO registerReturnDTO = await _userService.Register(registerDTO);

                return Ok(registerReturnDTO);

            }
            catch (UserAlreadyExistsException e)
            {
                return BadRequest(new ErrorModel(400, e.Message));
            }
            catch (PasswordException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(new ErrorModel(400, e.Message));
            }
            catch (UserException e)
            {
                return BadRequest(new ErrorModel(400, e.Message));
            }
            
            catch (Exception e)
            {
                return BadRequest(new ErrorModel(400, e.Message));
            }
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(RegisterReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterReturnDTO>> Login(Login loginDTO)
        {
            try
            {
                // Perform the login operation
                var loginResult = await _userService.Login(loginDTO);

                // Create a LoginReturnDTO with the result
                var registerReturnDTO = new RegisterReturnDTO
                {
                    UserId = loginResult.UserId,
                    Username = loginResult.Username
                };

                // Return the result in the response
                return Ok(registerReturnDTO);
            }
            catch (UnableToLoginException ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

    }
}
