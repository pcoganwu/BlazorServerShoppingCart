using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Products
{
    public class ProductListBase : ComponentBase
    {
        [Inject]
        public IProductViewModel ProductViewModel { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductViewModel.GetAllProducts();
        }
    }
}
