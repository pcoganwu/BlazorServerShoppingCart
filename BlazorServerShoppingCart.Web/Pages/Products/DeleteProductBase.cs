using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        [Parameter]
        public string ProductId { get; set; }

        protected Product Product { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Product = await ProductViewModel.GetProduct(ProductId);
        }

        protected async Task Handle_Delete()
        {
            Product = await ProductViewModel.GetProduct(ProductId);

            if (Product.ImageFile is not null)
            {
                string filePath = Path.Combine(WebHostEnvironment.WebRootPath, "images", "products", Product.ImageFile);
                //Delete file image file
                File.Delete(filePath);
            }

            await ProductViewModel.DeleteProduct(ProductId);
            NavigationManager.NavigateTo("/");
        }
    }
}
