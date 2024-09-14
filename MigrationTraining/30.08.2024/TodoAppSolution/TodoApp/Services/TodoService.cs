using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Context;
using TodoApp.Exceptions;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoAppContext _context;

        public TodoService(TodoAppContext context)
        {
            _context = context;
        }

        public async Task<TodoReturnDTO> AddTodo(AddTodoDTO todoDto)
        {
            var user = await _context.Users.FindAsync(todoDto.UserId);
            if (user == null)
            {
                throw new UserNotFoundException("User not found.");
            }
            // Map AddTodoDTO to Todo
            var todo = new Todo
            {   
               
                Title = todoDto.Title,
                Description = todoDto.Description,
                TargetDate = todoDto.TargetDate,
                Status = false,
                UserId = todoDto.UserId,
                UserName=user.Username
            };

            // Add Todo to the database
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            // Map Todo to TodoReturnDTO
            var todoReturnDto = new TodoReturnDTO
            {
                TodoId = todo.TodoId,
            };

            return todoReturnDto;
        }


        public async Task<TodoReturnDTO> DeleteTodo(int todoId)
        {
            try
            {
                // Retrieve the Todo entity by ID
                var todo = await _context.Todos
                    .Include(t => t.User) // Include User data to access UserName if needed
                    .FirstOrDefaultAsync(t => t.TodoId == todoId);

                if (todo == null)
                {
                    throw new TodoNotFoundException("Todo not found.");
                }

                // Remove the Todo from the database
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();

                // Map Todo to TodoReturnDTO
                var todoReturnDto = new TodoReturnDTO
                {
                    TodoId = todo.TodoId,
                    // Add other properties to TodoReturnDTO if needed
                };

                return todoReturnDto;
            }
            catch (TodoNotFoundException ex)
            {
                throw new TodoNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while deleting the Todo.", ex);
            }
        }

        public async Task<UpdateDTO> UpdateTodo(UpdateDTO todoDto)
        {
            try
            {
                // Retrieve the existing Todo with User data
                var todo = await _context.Todos
                    .Include(t => t.User) // Include User data to access UserName
                    .FirstOrDefaultAsync(t => t.TodoId == todoDto.TodoId);

                if (todo == null)
                {
                    throw new TodoNotFoundException("Todo not found.");
                }

                // Update the properties
                todo.Title = todoDto.Title;
                todo.Description = todoDto.Description;
                todo.TargetDate = todoDto.TargetDate;
                todo.Status = todoDto.Status;

                _context.Todos.Update(todo);
                await _context.SaveChangesAsync();

                // Get the Username by UserId
                var username = await GetUsernameByUserId(todo.UserId);

                // Map updated Todo to TodoDTO
                var updatedTodoDto = new UpdateDTO
                {
                    TodoId = todo.TodoId,
                    Title = todo.Title,
                    Description = todo.Description,
                    TargetDate = todo.TargetDate,
                    Status = todo.Status,
                };

                return updatedTodoDto;
            }
            catch (TodoNotFoundException ex)
            {
                throw new TodoNotFoundException(ex.Message);
            }
            
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while updating the Todo.", ex);
            }
        }

        public async Task<TodoDTO> GetTodoById(int todoId)
        {
            try
            {
                // Retrieve the Todo by ID along with the related User data
                var todo = await _context.Todos
                    .Include(t => t.User) // Include User data to access UserName
                    .FirstOrDefaultAsync(t => t.TodoId == todoId);

                if (todo == null)
                {
                    throw new TodoNotFoundException("Todo not found.");
                }

                // Map Todo to TodoDTO
                var todoDto = new TodoDTO
                {
                    TodoId = todo.TodoId,
                    Title = todo.Title,
                    Description = todo.Description,
                    TargetDate = todo.TargetDate,
                    Status = todo.Status,
                    UserId = todo.UserId,
                    UserName = todo.User?.Username // Use the User's Username if available
                };

                return todoDto;
            }
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while retrieving Todo by ID.", ex);
            }
        }


        public async Task<IEnumerable<TodoDTO>> GetAllTodos()
        {
            try
            {
                // Retrieve all Todos along with the related User data
                var todos = await _context.Todos
                    .Include(t => t.User) // Include User data to access UserName
                    .ToListAsync();

                // Map Todos to TodoDTOs
                var todoDtos = todos.Select(todo => new TodoDTO
                {
                    TodoId = todo.TodoId,
                    Title = todo.Title,
                    Description = todo.Description,
                    TargetDate = todo.TargetDate,
                    Status = todo.Status,
                    UserId = todo.UserId,
                    UserName = todo.User?.Username // Use the User's Username if available
                });

                return todoDtos;
            }
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while retrieving all Todos.", ex);
            }
        }

        public async Task<IEnumerable<UpdateDTO>> GetTodosByUserId(int userId)
        {
            try
            {
                // Retrieve all Todos for the specified UserId along with the related User data
                var todos = await _context.Todos
                    .Where(t => t.UserId == userId) // Filter Todos by UserId
                    .Include(t => t.User) // Include User data to access UserName
                    .ToListAsync();

                // Map Todos to TodoDTOs
                var todoDtos = todos.Select(todo => new UpdateDTO
                {
                    TodoId = todo.TodoId,
                    Title = todo.Title,
                    Description = todo.Description,
                    TargetDate = todo.TargetDate,
                    Status = todo.Status
                });

                return todoDtos;
            }
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while retrieving Todos for the specified user.", ex);
            }
        }


        private async Task<string> GetUsernameByUserId(int userId)
        {
            // Retrieve the User entity by UserId
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new UserNotFoundException("User not found.");
            }

            return user.Username;
        }

    }
}
