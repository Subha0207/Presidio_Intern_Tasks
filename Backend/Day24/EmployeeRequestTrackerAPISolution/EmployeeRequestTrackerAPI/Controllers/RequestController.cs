using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        
        [HttpPost("RaiseRequest")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Register([FromBody]RequestDetailsDTO requestDetailsDTO)
        {
            try
            {
                var result = await _requestService.RaiseRequest(requestDetailsDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetAllRequestsByAdmin")]
        [ProducesResponseType(typeof(RequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<RequestReturnDTO>>>GetAllRequests()
        {
            try
            {
                var result = await _requestService.GetAllOpenRequest();
                return Ok(result);
              }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }

        [Authorize]
        [HttpGet("GetRequestbyId")]
        [ProducesResponseType(typeof(RequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<RequestReturnDTO>>>GetRequestByUser(int empId)
        {
            try
            {
                var result = await _requestService.GetAllRequestByUser(empId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));


            }
        }
    }
}
