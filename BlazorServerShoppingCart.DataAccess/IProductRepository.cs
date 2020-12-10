using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetAllProducts();
        Task<Product> GetProduct(string productId);
        Task<Product> AddProduct(Product newProduct);
        Task<Product> UpdateProduct(Product updatedProduct);
        Task<Product> DeleteProduct(string productId);
    }
}
