using BlazorServerShoppingCart.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Utilities
{
    public class ProductsItem
    {
        public ProductViewModel ProductViewModel { get; set; } = new();

        public decimal Cost { get { return ProductViewModel.UnitPrice * (int)ProductViewModel.Quantity; } }
    }
}
