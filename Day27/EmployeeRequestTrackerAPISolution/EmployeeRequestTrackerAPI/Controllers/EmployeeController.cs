﻿using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        


        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("GetAllEmployees")]

        [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return Ok(employees.ToList());
            }
            catch (NoEmployeeFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }
        [HttpPut]
        [Route("UpdateEmployeePhone")]
        public async Task<ActionResult<Employee>> Put(int id, string phone)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee);
            }
            catch (NoSuchEmployeeException nsee)
            {
                return NotFound(nsee.Message);
            }
        }
        


        [Route("GetEmployeeByPhone")]

        [HttpPost]
        public async Task<ActionResult<Employee>> Get([FromBody] string phone)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(phone);

                return Ok(employee);

            }

            catch (NoSuchEmployeeException nefe)

            {

                return NotFound(nefe.Message);

            }

        }
    }
}
