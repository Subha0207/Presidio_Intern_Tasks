﻿using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    
    public class UserRepository : IRepository<int, User>
    {
        private RequestTrackerContext _context;

        public UserRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            item.Status = "Disabled";
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }

        public async Task<User> Get(int key)
        {
            return (await _context.Users.SingleOrDefaultAsync(u => u.EmployeeId == key)) ?? throw new Exception("No user with the given ID");
        }

        public async Task<IEnumerable<User>> Get()
        {
            return (await _context.Users.ToListAsync());
        }

        public async Task<User> Update(User item)
        {
            var user = await Get(item.EmployeeId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }
    }
}


