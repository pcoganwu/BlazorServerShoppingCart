using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.ViewModels
{
    public interface IInvoiceDataViewModel
    {
        public decimal SalesTax { get; set; }

        Task<IList<InvoiceDatum>> InvoiceData();
    }
}
