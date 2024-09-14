using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TodoApp.Context;
using TodoApp.Exceptions;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Repository
{
    public class UserRepository : IRepository<int, User>
    {

        private readonly TodoAppContext _context;

        public UserRepository(TodoAppContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            try
            {
                
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            

            catch (Exception ex)
            {
                throw new UserException("Error occurred while adding user.", ex);
            }
        }
    

        
            public async Task<User> Delete(int key)
            {
                try
                {
                    var user = await Get(key);
                    _context.Remove(user);
                    await _context.SaveChangesAsync(true);
                    return user;
                }
                catch (UserNotFoundException ex)
                {
                    throw new UserException("Error occurred while deleting user: " + ex.Message, ex);
                }
                catch (Exception ex)
                {
                    throw new UserException("Error occurred while deleting user.", ex);
                }
            }

        

        public async Task<User> Get(int key)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == key);
                if (user != null)
                {
                    return user;
                }
                
                throw new UserNotFoundException("No such user found.");
            }
            catch (UserNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserException("Error occurred while getting user.", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
           try {
                var users = await _context.Users.ToListAsync();
                if (users.Count <= 0)
                {
                    throw new UserNotFoundException("There is no user present.");
                }
                return users;
            }
            catch (UserNotFoundException ex)
            {
                throw new UserException("Error occurred while retrieving users: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new UserException("Error occurred while retrieving users.", ex);
            }
        }

        public async Task<User> Update(User item)
        {
            try
            {
                var user = await Get(item.UserId);
                _context.Update(user);
                await _context.SaveChangesAsync(true);
                return user;
            }
            catch (UserNotFoundException ex)
            {
                throw new UserException("Error occurred while updating user. User not found: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new UserException("Error occurred while updating user.", ex);
            }
        }
    }
}
