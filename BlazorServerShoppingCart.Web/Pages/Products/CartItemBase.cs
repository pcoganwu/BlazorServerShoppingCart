using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Products
{
    public class CartItemBase : ComponentBase
    {
        [Parameter]
        public string ProductId { get; set; }

        [Parameter]
        public int Quantity { get; set; }
    }
}
