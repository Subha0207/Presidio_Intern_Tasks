using TodoApp.Models;

namespace TodoApp.Interfaces
{
    public interface ITodoService
    {

        Task<TodoReturnDTO> AddTodo(AddTodoDTO todoDto);
        Task<TodoDTO> GetTodoById(int todoId);
        Task<IEnumerable<TodoDTO>> GetAllTodos();
        Task<UpdateDTO> UpdateTodo(UpdateDTO todoDto);
        Task<TodoReturnDTO> DeleteTodo(int todoId);

        public Task<IEnumerable<UpdateDTO>> GetTodosByUserId(int userId);
    }
}
