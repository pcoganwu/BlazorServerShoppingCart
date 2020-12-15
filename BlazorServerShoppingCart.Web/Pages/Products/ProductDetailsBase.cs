using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Products
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public string ProductId { get; set; }

        public Product Product { get; set; } = new();

        [Inject]
        public IProductViewModel ProductViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Product = await ProductViewModel.GetProduct(ProductId);
        }
    }
}
