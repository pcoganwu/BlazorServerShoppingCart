using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public interface IInvoiceDataRepository
    {
        Task<IList<InvoiceDatum>> GetSalesTax();
    }
}
