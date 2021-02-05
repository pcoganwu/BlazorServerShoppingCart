using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.ViewModels
{
    public interface IProductViewModel
    {
        
        string ProductId { get; set; }
        string Name { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        string CategoryId { get; set; }
        string ImageFile { get; set; }
        decimal UnitPrice { get; set; }
        int OnHand { get; set; }
        int? Quantity { get; set; }

        Category Category { get; set; }
        ICollection<LineItem> LineItems { get; set; }
        Task<IList<Product>> GetAllProducts();
        Task<Product> GetProduct(string productId);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<IList<ProductCount>> ProductCountByCategory();
        Task DeleteProduct(string productId);
        Task<ProductViewModel> GetOrderProduct(string productId);
    }
}
