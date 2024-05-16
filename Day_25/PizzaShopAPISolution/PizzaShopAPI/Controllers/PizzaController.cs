
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

       public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        [HttpGet]
        [Route("GetAllPizzas")]


        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Pizza>>> GetAllPizzas()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllPizzas();
                return Ok(pizzas.ToList());

            }

            catch (NoPizzaFoundException npfe)
            {
                return NotFound(npfe.Message);
            }


        }
        [HttpGet]
        [Route("GetPizzasInStock")]


        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Pizza>>> GetPizzaOnlyInStock(bool instock)
        {
            try
            {
                var pizzas = await _pizzaService.GetPizzaOnlyInStock(instock);
                return Ok(pizzas.ToList());

            }

            catch (NoPizzaFoundException npfe)
            {
                return NotFound(npfe.Message);
            }


        }

    }
}
