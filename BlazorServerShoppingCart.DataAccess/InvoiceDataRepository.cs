using BlazorServerShoppingCart.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public class InvoiceDataRepository : IInvoiceDataRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvoiceDataRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IList<InvoiceDatum>> GetSalesTax()
        {
            return await _appDbContext.InvoiceData.ToListAsync();
        }
    }
}
