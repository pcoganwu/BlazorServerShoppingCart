using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.Utilities;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        [Inject]
        public IFileUpload FileUpload { get; set; }

        protected IBrowserFile Photo { get; set; }

        [Parameter]
        public string ProductId { get; set; }

        protected string PageTitle { get; set; }

        protected string ButtonTitle { get; set; }

        protected string FileInputText { get; set; }


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

        protected async Task HandleFileSelectedAsync(InputFileChangeEventArgs e)
        {
            Photo = e.File;
            FileInputText = e.File.Name;

            if (Photo is not null)
            {
                if (Product.ImageFile is not null)
                {
                    var fileName = Path.Combine(WebHostEnvironment.WebRootPath, "images", "products", Product.ImageFile);
                    File.Delete(fileName);
                }
                Product.ImageFile = await FileUpload.Upload(Photo);
            }
        }
    }
}
