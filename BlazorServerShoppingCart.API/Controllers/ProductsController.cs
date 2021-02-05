using BlazorServerShoppingCart.DataAccess;
using BlazorServerShoppingCart.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorServerShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<Product>> GetAllProducts()
        {
            try
            {
                return Ok(await _productRepository.GetAllProducts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // GET api/<ProductsController>/5
        // GET api/<Products>/5
        [HttpGet("{GetProduct}/{productId}")]
        public async Task<ActionResult<Product>> GetProduct(string productId)
        {
            try
            {
                return Ok(await _productRepository.GetProduct(productId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{ProductCountByCategory}")]
        public async Task<ActionResult<ProductCount>> ProductCountByCategory()
        {
            try
            {
                return Ok(await _productRepository.ProductCountByCategory());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }

        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product newProduct)
        {
            try
            {
                var product = await _productRepository.AddProduct(newProduct);
                return CreatedAtAction(nameof(GetProduct), new { productId = product.ProductId }, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding a new product to the database");
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut()]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product newProduct)
        {
            try
            {
                if (newProduct is null)
                {
                    return BadRequest("Invalid request");
                }

                var product = await _productRepository.GetProduct(newProduct.ProductId);
                if (product is not null)
                {
                    return await _productRepository.UpdateProduct(newProduct);
                }
                return NotFound($"Product with ID = {newProduct.ProductId} cannot be found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating product in the database");
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{productId}")]
        public async Task<ActionResult<Product>> DeleteProduct(string productId)
        {
            try
            {
                var product = await _productRepository.GetProduct(productId);
                if (product is not null)
                {
                    return await _productRepository.DeleteProduct(productId);
                }
                return NotFound($"Product with ID = {productId} cannot be found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting product in the database");
            }
        }
    }
}
