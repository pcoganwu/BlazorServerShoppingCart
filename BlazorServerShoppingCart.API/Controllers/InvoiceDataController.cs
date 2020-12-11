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
    public class InvoiceDataController : ControllerBase
    {
        private readonly IInvoiceDataRepository _invoiceDataRepository;

        public InvoiceDataController(IInvoiceDataRepository invoiceDataRepository)
        {
            _invoiceDataRepository = invoiceDataRepository;
        }
        // GET: api/<InvoiceDataController>
        [HttpGet]
        public async Task<ActionResult<InvoiceDatum>> GetAllInvoiceData()
        {
            try
            {
                return Ok(await _invoiceDataRepository.GetSalesTax());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
    }
}
