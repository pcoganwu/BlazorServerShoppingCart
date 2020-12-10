using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public interface IInvoiceRepository
    {
        Task<IList<Invoice>> GetAllInvoices();
        Task<Invoice> GetInvoice(int invoiceNumber);
        Task<Invoice> AddInvoice(Invoice newInvoice);
        Task<Invoice> UpdateInvoice(Invoice updatedInvoice);
        Task<Invoice> DeleteInvoice(int invoiceNumber);
    }
}
