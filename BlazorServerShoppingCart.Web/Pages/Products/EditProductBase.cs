using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Products
{
    public class EditProductBase : ComponentBase
    {
        [Inject]
        public IProductViewModel ProductViewModel { get; set; }

        [Inject]
        public ICategoryViewModel CategoryViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string ProductId { get; set; }

        protected string PageTitle { get; set; }

        protected string ButtonTitle { get; set; }

        protected Product Product { get; set; } = new();

        protected IList<Category> Categories { get; set; } = new List<Category>();

        protected override async Task OnInitializedAsync()
        {
            if (ProductId is null)
            {
                Product = new();
                Categories = await CategoryViewModel.GetAllCategories();
                PageTitle = "Add New Product";
                ButtonTitle = "ADD";
            }
            else
            {
                Product = await ProductViewModel.GetProduct(ProductId);
                Categories = await CategoryViewModel.GetAllCategories();
                PageTitle = $"Updating Product with ID {Product.ProductId}";
                ButtonTitle = "Update";
            }
        }

        protected async Task Handle_Valid_Submit()
        {
            if (ProductId is null)
            {
                await ProductViewModel.AddProduct(Product);
                NavigationManager.NavigateTo("/");
            }
            else
            {
                await ProductViewModel.UpdateProduct(Product);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
