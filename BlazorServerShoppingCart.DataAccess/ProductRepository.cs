using BlazorServerShoppingCart.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> AddProduct(Product newProduct)
        {
            var product = await _appDbContext.Products.AddAsync(newProduct);
            await _appDbContext.SaveChangesAsync();
            return product.Entity;
        }

        public async Task<Product> DeleteProduct(string productId)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product != null)
            {
                _appDbContext.Products.Remove(product);
                await _appDbContext.SaveChangesAsync();
                return product;
            }
            return null;
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            return await _appDbContext.Products.Include(c => c.Category).ToListAsync();
        }

        public async Task<Product> GetProduct(string productId)
        {
            return await _appDbContext.Products.Include(c => c.Category).FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<Product> UpdateProduct(Product updatedProduct)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == updatedProduct.ProductId);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.ShortDescription = updatedProduct.ShortDescription;
                product.LongDescription = updatedProduct.LongDescription;
                product.CategoryId = updatedProduct.CategoryId;
                product.ImageFile = updatedProduct.ImageFile;
                product.UnitPrice = updatedProduct.UnitPrice;
                product.OnHand = updatedProduct.OnHand;

                await _appDbContext.SaveChangesAsync();
                return product;
            }
            return null;
        }
    }
}
