using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.Utilities;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Products
{
    public class CheckoutBase : ComponentBase
    {
        [CascadingParameter]
        public CartStateProvider CartStateProvider { get; set; }

        [Inject]
        public IInvoiceDataViewModel _InvoiceDataViewModel { get; set; }

        public IList<InvoiceDatum> TAX { get; set; } = new List<InvoiceDatum>();

        protected override async Task OnInitializedAsync()
        {
            TAX = await _InvoiceDataViewModel.InvoiceData();
        }

    }
}
