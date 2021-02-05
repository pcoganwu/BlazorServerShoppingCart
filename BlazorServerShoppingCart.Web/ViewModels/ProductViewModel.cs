using BlazorServerShoppingCart.Models.Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.ViewModels
{
    public class ProductViewModel : IProductViewModel
    {
        private readonly HttpClient _httpClient;

        public Product Product { get; set; } = new();

        public ProductViewModel()
        { }

        public ProductViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Required, MaxLength(10), Display(Name = "Product ID")]
        public string ProductId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(200), Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Required, MaxLength(2000), Display(Name = "Long Description")]
        public string LongDescription { get; set; }
        [Required, MaxLength(10), Display(Name = "Category ID")]
        public string CategoryId { get; set; }
        [MaxLength(400), Display(Name = "Image File")]
        public string ImageFile { get; set; }
        [Required, Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Required, Display(Name = "On Hand")]
        public int OnHand { get; set; }
        [Required, Range(1, 500)]
        public int? Quantity { get; set; }

        public Category Category { get; set; }
        public ICollection<LineItem> LineItems { get; set; }

        public async Task<Product> AddProduct(Product product)
        {
            return await _httpClient.PostJsonAsync<Product>("api/products", product);
        }

        public async Task DeleteProduct(string productId)
        {
            await _httpClient.DeleteAsync($"api/products/{productId}");
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            return await _httpClient.GetJsonAsync<List<Product>>("api/products");
        }

        public async Task<Product> GetProduct(string productId)
        {
            return await _httpClient.GetJsonAsync<Product>($"api/products/GetProduct/{productId}");
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await _httpClient.PutJsonAsync<Product>($"api/products", product);
        }

        public async Task<ProductViewModel> GetOrderProduct(string productId)
        {
            Product = await this.GetProduct(productId);
            return LoadCurrentObject(Product);
        }

        private ProductViewModel LoadCurrentObject(ProductViewModel productViewModel)
        {
            ProductId = productViewModel.ProductId;
            Name = productViewModel.Name;
            ShortDescription = productViewModel.ShortDescription;
            LongDescription = productViewModel.LongDescription;
            CategoryId = productViewModel.CategoryId;
           ImageFile = productViewModel.ImageFile;
            UnitPrice = productViewModel.UnitPrice;
            OnHand = productViewModel.OnHand;
            Category = productViewModel.Category;

            return productViewModel;
        }

        public async Task<IList<ProductCount>> ProductCountByCategory()
        {
            return await _httpClient.GetJsonAsync<List<ProductCount>>("api/products/ProductCountByCategory");
        }

        //Mapping ProductViewModel to Product from the database
        public static implicit operator ProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                CategoryId = product.CategoryId,
                ImageFile = product.ImageFile,
                UnitPrice = product.UnitPrice,
                OnHand = product.OnHand,
                Category = product.Category
            };
        }

        //Mapping Product from database to ProductViewModel
        public static implicit operator Product(ProductViewModel productViewModel)
        {
            return new Product
            {
                ProductId = productViewModel.ProductId,
                Name = productViewModel.Name,
                ShortDescription = productViewModel.ShortDescription,
                LongDescription = productViewModel.LongDescription,
                CategoryId = productViewModel.CategoryId,
                ImageFile = productViewModel.ImageFile,
                UnitPrice = productViewModel.UnitPrice,
                OnHand = productViewModel.OnHand,
                Category = productViewModel.Category
            };
        }
    }
}
