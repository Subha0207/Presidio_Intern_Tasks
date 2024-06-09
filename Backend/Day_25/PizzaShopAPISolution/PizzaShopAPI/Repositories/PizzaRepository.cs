using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Models;


namespace PizzaShopAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaShopContext _context;

        public PizzaRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                _context.Remove(pizza);
                _context.SaveChangesAsync();
                return pizza;
            }

            throw new Exception("No pizza with the given ID");
        }

        public async Task<Pizza> Get(int key)
        {
            return (await _context.Pizzas.SingleOrDefaultAsync(u => u.Id == key)) ?? throw new Exception("No pizza with the given ID");
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            return (await _context.Pizzas.ToListAsync()) ?? throw new Exception("No Pizzas found");
        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.Id);
            if (pizza != null)
            {

                _context.Update(item);
                await _context.SaveChangesAsync();
                return pizza;

            }
            throw new Exception("No Pizza with given Id");
        }
    }
}
