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
    public class ProductListBase : ComponentBase
    {
        [Inject]
        public IProductViewModel ProductViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public CartStateProvider CartStateProvider { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductViewModel.GetAllProducts();
        }

        protected void GoToCart()
        {
            NavigationManager.NavigateTo($"/Cartitem/" +
                $"{(CartStateProvider.ShoppingCart.Items).FirstOrDefault().ProductViewModel.ProductId}");
        }
    }
}
