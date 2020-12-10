using BlazorServerShoppingCart.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public class LineItemRepository : ILineItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public LineItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<LineItem> AddLineItem(LineItem newLineItem)
        {
            var lineItem = await _appDbContext.LineItems.AddAsync(newLineItem);
            await _appDbContext.SaveChangesAsync();
            return lineItem.Entity;
        }

        public async Task<LineItem> DeleteLineItem(int invoiceNumber)
        {
            //Find the lineitem to delete
            var invoice = await _appDbContext.LineItems.FirstOrDefaultAsync(l => l.InvoiceNumber == invoiceNumber);
            if (invoice != null)
            {
                _appDbContext.LineItems.Remove(invoice);
                await _appDbContext.SaveChangesAsync();
                return invoice;
            }
            return null;
        }

        public async Task<IList<LineItem>> GetAllLineItems()
        {
            return await _appDbContext.LineItems.ToListAsync();
        }

        public async Task<LineItem> GetLineItem(int invoiceNumber)
        {
            return await _appDbContext.LineItems.FirstOrDefaultAsync(l => l.InvoiceNumber == invoiceNumber);
        }

        public async Task<LineItem> UpdateLineItem(LineItem updatedLineItem)
        {
            //Find the lineitem to delete
            var invoice = await _appDbContext.LineItems.FirstOrDefaultAsync(l => l.InvoiceNumber == updatedLineItem.InvoiceNumber);
            if (invoice != null)
            {
                invoice.ProductId = updatedLineItem.ProductId;
                invoice.UnitPrice = updatedLineItem.UnitPrice;
                invoice.Quantity = updatedLineItem.Quantity;

                await _appDbContext.SaveChangesAsync();
                return invoice;
            }
            return null;
        }
    }
}
