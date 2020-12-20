using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Products
{
    public class OrderBase : ComponentBase
    {
        [Inject]
        public IProductViewModel _ProductViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string ProductId { get; set; }

        protected IList<Product> Products{ get; set; } = new List<Product>();
        protected ProductViewModel ProductViewModel { get; set; } = new ProductViewModel();


        protected override async Task OnInitializedAsync()
        {
            Products = await _ProductViewModel.GetAllProducts();
            ProductViewModel = await _ProductViewModel.GetOrderProduct(ProductId);
        }

        protected async Task GetProductAsync(string value)
        {
            ProductViewModel = await _ProductViewModel.GetOrderProduct(value);
        }

        protected void Handle_Submit()
        {
            NavigationManager.NavigateTo($"/CartItem/{ProductViewModel.ProductId}/{ProductViewModel.Quantity}");
        }
    }
}
