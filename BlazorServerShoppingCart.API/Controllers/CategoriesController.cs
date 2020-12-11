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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<Category>> GetAllCategories()
        {
            try
            {
                return Ok(await _categoryRepository.GetAllCategories());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<Category>> GetCategory(string categoryId)
        {
            try
            {
                return await _categoryRepository.GetCategory(categoryId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category newCategory)
        {
            try
            {
                
               var categoryToCreate = await _categoryRepository.AddCategory(newCategory);
                return CreatedAtAction(nameof(GetCategory), new { categoryId = categoryToCreate.CategoryId }, categoryToCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a new category");
            }
        }

        // PUT api/<CategoriesController>
        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory([FromBody] Category updatedCategory)
        {
            try
            {
                if (updatedCategory is null)
                {
                    return BadRequest("Invalid request");
                }
                var categoryToUpdate = await _categoryRepository.GetCategory(updatedCategory.CategoryId);
                if (categoryToUpdate is not null)
                {
                    return await _categoryRepository.UpdateCategory(updatedCategory);
                }
                else
                {
                    return NotFound($"The category with ID = {updatedCategory.CategoryId} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the category");
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{categoryId}")]
        public async Task<ActionResult<Category>> Delete(string categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetCategory(categoryId);
                if (category is not null)
                {
                    return await _categoryRepository.DeleteCategory(categoryId);
                }
                else
                {
                    return NotFound($"The category with ID = {categoryId} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the category");
            }
        }
    }
}
