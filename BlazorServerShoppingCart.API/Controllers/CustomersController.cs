using BlazorServerShoppingCart.DataAccess;
using BlazorServerShoppingCart.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetAllCustomers()
        {
            try
            {
                return Ok(await _customerRepository.GetAllCustomers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Customer>> GetCustomer(string email)
        {
            try
            {
                return await _customerRepository.GetCustomer(email);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                var customerToCreate = await _customerRepository.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomer), new { email = customerToCreate.Email }, customerToCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new customer");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer is null)
                {
                    return BadRequest("Invalid request");
                }

                var customerToUpdate = await _customerRepository.GetCustomer(customer.Email);
                if (customerToUpdate is not null)
                {
                    return await _customerRepository.UpdateCustomer(customer);
                }
                else
                {
                    return NotFound($"Customer with email = {customer.Email} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the customer");
            }
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(string email)
        {
            try
            {
                var customer = await _customerRepository.GetCustomer(email);
                if (customer is not null)
                {
                    return await _customerRepository.DeleteCustomer(email);
                }
                else
                {
                    return NotFound($"Customer with email = {email} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the customer");
            }
            
        }
    }
}
