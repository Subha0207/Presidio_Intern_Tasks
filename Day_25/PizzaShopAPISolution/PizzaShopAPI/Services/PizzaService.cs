using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Repositories;

namespace PizzaShopAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;

       public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            var pizzas = await _repository.GetAll();
            if (pizzas.Count() == 0)
            {
                throw new Exception("No pizzas found");
            }
            return pizzas;


            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pizza>> GetPizzaOnlyInStock()
        {
            var pizzas = await _repository.GetAll();
            List<Pizza> pizzaInStock = [];

            if (pizzas.Count() != 0)
            {
                foreach (var pizza in pizzas)
                {
                    if (pizza.InStock)
                    {
                        pizzaInStock.Add(pizza);

                    }
                }

                return pizzaInStock;
            }

            throw new Exception("Pizzas are out of stock");
        }
    }
}
