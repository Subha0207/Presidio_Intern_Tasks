using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Exceptions;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(IList<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IList<Product>>> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products.ToList());
            }
            catch (NoProductFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }




        [Route("GetProductsByID")]
        [HttpGet]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductsByID([FromBody] int id)
        {
            try
            {
                var products = await _productService.GetProductByID(id);
                return Ok(products);
            }
            catch (NoProductFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
    }
}
