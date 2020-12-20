using BlazorServerShoppingCart.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Utilities
{
    public class ProductsItem
    {
        private readonly IProductViewModel productViewModel;

        public ProductsItem(IProductViewModel productViewModel)
        {
            this.productViewModel = productViewModel;
        }

        public decimal Total { get { return productViewModel.UnitPrice * (int)productViewModel.Quantity; } }
    }
}
