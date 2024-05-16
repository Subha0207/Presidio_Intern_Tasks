
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
        [HttpGet]
        [Route("GetPizzasInStock")]


        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Pizza>>> GetPizzaOnlyInStock()
        {
            try
            {
                var pizzas = await _pizzaService.GetPizzaOnlyInStock();
                return Ok(pizzas.ToList());

            }

            catch (NoPizzaFoundException npfe)
            {
                return NotFound(npfe.Message);
            }


        }

    }
}
