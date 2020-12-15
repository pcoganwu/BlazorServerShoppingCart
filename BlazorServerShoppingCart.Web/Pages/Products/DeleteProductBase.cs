using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Products
{
    public class DeleteProductBase : ComponentBase
    {
        [Inject]
        public IProductViewModel ProductViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string ProductId { get; set; }

        protected Product Product { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Product = await ProductViewModel.GetProduct(ProductId);
        }

        protected async Task Handle_Delete()
        {
            await ProductViewModel.DeleteProduct(ProductId);
            NavigationManager.NavigateTo("/");
        }
    }
}
