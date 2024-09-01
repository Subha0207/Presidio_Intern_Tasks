using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Exceptions;
using TodoApp.Interfaces;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTodo([FromBody] AddTodoDTO todoDto)
        {
            try
            {
                var result = await _todoService.AddTodo(todoDto);
                return Ok(result);
            }
            catch (TodoException ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpDelete("delete/{id}")]

        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                var result = await _todoService.DeleteTodo(id);
                return Ok(result);
            }
            catch (TodoNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (TodoException ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTodos()
        {
            try
            {
                var todos = await _todoService.GetAllTodos();
                return Ok(todos);
            }
            catch (TodoNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (TodoException ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }
        [HttpGet("all{userId}")]
        public async Task<IActionResult> GetAllTodosByUserId(int userId)
        {
            try
            {
                var todos = await _todoService.GetTodosByUserId(userId);
                return Ok(todos);
            }
            catch (TodoException ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            try
            {
                var todo = await _todoService.GetTodoById(id);
                return Ok(todo);
            }
            catch (TodoException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateDTO todoDto)
        {
            try
            {
                var updatedTodo = await _todoService.UpdateTodo(todoDto);
                return Ok(updatedTodo);
            }
            catch (TodoException ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }
    }
}
