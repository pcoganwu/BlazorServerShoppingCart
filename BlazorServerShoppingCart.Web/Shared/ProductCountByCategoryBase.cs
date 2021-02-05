using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Shared
{
    public class ProductCountByCategoryBase : ComponentBase
    {
        [Inject]
        public IProductViewModel ProductViewModel { get; set; }

        public IList<ProductCount> ProductCount { get; set; } = new List<ProductCount>();

        [Parameter]
        public string Category { get; set; } 

        protected override async Task OnInitializedAsync()
        {
            ProductCount = await ProductViewModel.ProductCountByCategory();
        }
    }
}
