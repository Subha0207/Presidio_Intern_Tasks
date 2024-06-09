
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Interfaces
{
    public interface IPizzaService
    {
        public Task<IEnumerable<Pizza>> GetAllPizzas();
        public Task<IEnumerable<Pizza>> GetPizzaOnlyInStock();
    }
}
