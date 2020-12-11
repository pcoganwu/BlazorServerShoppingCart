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
    public class LineItemsController : ControllerBase
    {
        private readonly ILineItemRepository _lineItemRepository;

        public LineItemsController(ILineItemRepository lineItemRepository)
        {
            _lineItemRepository = lineItemRepository;
        }

        // GET: api/<LineItemsController>
        [HttpGet]
        public async Task<ActionResult<LineItem>> GetAllLineItems()
        {
            try
            {
                return Ok(await _lineItemRepository.GetAllLineItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // GET api/<LineItemsController>/5
        [HttpGet("{invoiceNumber}")]
        public async Task<ActionResult<LineItem>> GetLineItem(int invoiceNumber)
        {
            try
            {
                return Ok((await _lineItemRepository.GetAllLineItems())
                        .Where(l => l.InvoiceNumber == invoiceNumber).ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // POST api/<LineItemsController>
        [HttpPost]
        public async Task<ActionResult<LineItem>> CreateLineItem([FromBody] LineItem lineItem)
        {
            try
            {
                var lineItemToCreate = await _lineItemRepository.AddLineItem(lineItem);
                return CreatedAtAction(nameof(GetLineItem), new { invoiceNumber = lineItemToCreate.InvoiceNumber }, lineItemToCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a new line item");
            }
        }

        // PUT api/<LineItemsController>/5
        [HttpPut()]
        public async Task<ActionResult<LineItem>> UpdateLineItem([FromBody] LineItem lineItem)
        {
            try
            {
                if (lineItem is null)
                {
                    return BadRequest("Invalid request");
                }

                var lineItemToUpdate = await _lineItemRepository.GetLineItem(lineItem.InvoiceNumber);
                if (lineItemToUpdate is not null)
                {
                    return await _lineItemRepository.UpdateLineItem(lineItem);
                }
                else
                {
                    return NotFound($"Line Item with invoice number = {lineItem.InvoiceNumber} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the line item");
            }
        }

        // DELETE api/<LineItemsController>/5
        [HttpDelete("{invoiceNumber}")]
        public async Task<ActionResult<LineItem>> DeleteInvoiceNumber(int invoiceNumber)
        {
            try
            {
                var lineItemToDelete = await _lineItemRepository.GetLineItem(invoiceNumber);
                if (lineItemToDelete is not null)
                {
                    return await _lineItemRepository.DeleteLineItem(invoiceNumber);
                }
                else
                {
                    return NotFound($"Line Item with invoice number = {invoiceNumber} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting line item");
            }
        }
    }
}
