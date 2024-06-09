
using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Models;
using PizzaShopAPI.Repositories;

namespace PizzaShopAPI.Repositories
{

    public class UserCredentialRepository : IRepository<int, UserCredential>
    {
        private PizzaShopContext _context;

        public UserCredentialRepository(PizzaShopContext context)
        {
            _context = context;
        }

        public async Task<UserCredential> Add(UserCredential item)
        {

            item.Status = "Disabled";
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<UserCredential> Delete(int key)
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

        public async Task<UserCredential> Get(int key)
        {
            return (await _context.UserCredentials.SingleOrDefaultAsync(u => u.UserId == key)) ?? throw new Exception("No user with the given ID");

        }

        public async Task<IEnumerable<UserCredential>> GetAll()
        {
            return await _context.UserCredentials.ToListAsync();

        }

        public async Task<UserCredential> Update(UserCredential item)
        {

            var user = await Get(item.UserId);
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


