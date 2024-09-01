using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TodoApp.Context;
using TodoApp.Exceptions;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Repository
{
    public class TodoRepository : IRepository<int, Todo>
    {
        private readonly TodoAppContext _context;

        public TodoRepository(TodoAppContext context)
        {
            _context = context;
        }

        public async Task<Todo> Add(Todo item)
        {
            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while adding todo item.", ex);
            }
        }

        public async Task<Todo> Delete(int key)
        {
            try
            {
                var todo = await Get(key);
                _context.Remove(todo);
                await _context.SaveChangesAsync(true);
                return todo;
            }
            catch (TodoNotFoundException ex)
            {
                throw new TodoException("Error occurred while deleting todo item: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while deleting todo item.", ex);
            }
        }

        public async Task<Todo> Get(int key)
        {
            try
            {
                var todo = await _context.Todos.FirstOrDefaultAsync(t => t.TodoId == key);
                if (todo != null)
                {
                    return todo;
                }

                throw new TodoNotFoundException("No such todo item found.");
            }
            catch (TodoNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while retrieving todo item.", ex);
            }
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            try
            {
                var todos = await _context.Todos.ToListAsync();
                if (todos.Count <= 0)
                {
                    throw new TodoNotFoundException("No todo items are present.");
                }
                return todos;
            }
            catch (TodoNotFoundException ex)
            {
                throw new TodoException("Error occurred while retrieving todo items: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while retrieving todo items.", ex);
            }
        }

        public async Task<Todo> Update(Todo item)
        {
            try
            {
                var todo = await Get(item.TodoId);
                _context.Update(todo);
                await _context.SaveChangesAsync(true);
                return todo;
            }
            catch (TodoNotFoundException ex)
            {
                throw new TodoException("Error occurred while updating todo item. Todo item not found: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new TodoException("Error occurred while updating todo item.", ex);
            }
        }
    }
}
