using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public interface ILineItemRepository
    {
        Task<IList<LineItem>> GetAllLineItems();
        Task<LineItem> GetLineItem(int invoiceNumber);
        Task<LineItem> AddLineItem(LineItem newLineItem);
        Task<LineItem> UpdateLineItem(LineItem updatedLineItem);
        Task<LineItem> DeleteLineItem(int invoiceNumber);
    }
}
