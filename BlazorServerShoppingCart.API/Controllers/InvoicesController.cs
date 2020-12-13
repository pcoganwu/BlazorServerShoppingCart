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
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepsoitory;

        public InvoicesController(IInvoiceRepository invoiceRepsoitory)
        {
            _invoiceRepsoitory = invoiceRepsoitory;
        }

        // GET: api/<InvoicesController>
        [HttpGet]
        public async Task<ActionResult<Invoice>> GetAllInvoices()
        {
            try
            {
                return Ok(await _invoiceRepsoitory.GetAllInvoices());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // GET api/<InvoicesController>/5
        [HttpGet("{invoiceNumber}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int invoiceNumber)
        {
            try
            {
                return await _invoiceRepsoitory.GetInvoice(invoiceNumber);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // POST api/<InvoicesController>
        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice([FromBody] Invoice invoice)
        {
            try
            {
                var invoiceToCreate = await _invoiceRepsoitory.AddInvoice(invoice);
                return CreatedAtAction(nameof(GetInvoice), new { invoiceNumber = invoiceToCreate.InvoiceNumber }, invoiceToCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a new invoice");
            }
            
        }

        // PUT api/<InvoicesController>/5
        [HttpPut()]
        public async Task<ActionResult<Invoice>> UpdateInvoice([FromBody] Invoice invoice)
        {
            try
            {
                if (invoice is null)
                {
                    return BadRequest("Invalid request");
                }
                var invoiceToUpdate = await _invoiceRepsoitory.GetInvoice(invoice.InvoiceNumber);
                if (invoiceToUpdate is not null)
                {
                    return await _invoiceRepsoitory.UpdateInvoice(invoice);
                }
                else
                {
                    return NotFound($"Invoice with invoice number = {invoice.InvoiceNumber} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the invoice");
            }
        }

        // DELETE api/<InvoicesController>/5
        [HttpDelete("{invoiceNumber}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int invoiceNumber)
        {
            try
            {
                var invoice = await _invoiceRepsoitory.GetInvoice(invoiceNumber);
                if (invoice is not null)
                {
                    return await _invoiceRepsoitory.DeleteInvoice(invoiceNumber);
                }
                else
                {
                    return NotFound($"Invoice with invoice number = {invoiceNumber} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting invoice");
            }
        }
    }
}
