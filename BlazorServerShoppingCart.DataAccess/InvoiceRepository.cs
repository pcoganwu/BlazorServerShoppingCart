using BlazorServerShoppingCart.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvoiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Invoice> AddInvoice(Invoice newInvoice)
        {
            var invoice = await _appDbContext.Invoices.AddAsync(newInvoice);
            await _appDbContext.SaveChangesAsync();
            return invoice.Entity;
        }

        public async Task<Invoice> DeleteInvoice(int invoiceNumber)
        {
            //Find the invoice to delete
            var invoice = await _appDbContext.Invoices.FirstOrDefaultAsync(i => i.InvoiceNumber == invoiceNumber);
            if (invoice != null)
            {
                _appDbContext.Invoices.Remove(invoice);
                await _appDbContext.SaveChangesAsync();
                return invoice;
            }
            return null;
        }

        public async Task<IList<Invoice>> GetAllInvoices()
        {
            return await _appDbContext.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoice(int invoiceNumber)
        {
            return await _appDbContext.Invoices.FirstOrDefaultAsync(i => i.InvoiceNumber == invoiceNumber); ;
        }

        public async Task<Invoice> UpdateInvoice(Invoice updatedInvoice)
        {
            //Find the invoice to update
            var invoice = await _appDbContext.Invoices.FirstOrDefaultAsync(i => i.InvoiceNumber == updatedInvoice.InvoiceNumber);
            if (invoice != null)
            {
                //Update invoice with data from the incoming invoice object
                invoice.CustEmail = updatedInvoice.CustEmail;
                invoice.OrderDate = updatedInvoice.OrderDate;
                invoice.Subtotal = updatedInvoice.Subtotal;
                invoice.ShipMethod = updatedInvoice.ShipMethod;
                invoice.Shipping = updatedInvoice.Shipping;
                invoice.SalesTax = updatedInvoice.SalesTax;
                invoice.Total = updatedInvoice.Total;
                invoice.CreditCardType = updatedInvoice.CreditCardType;
                invoice.CardNumber = updatedInvoice.CardNumber;
                invoice.ExpirationMonth = updatedInvoice.ExpirationMonth;
                invoice.ExpirationYear = updatedInvoice.ExpirationYear;

                await _appDbContext.SaveChangesAsync();
                return invoice;
            }
            return null;
        }
    }
}
