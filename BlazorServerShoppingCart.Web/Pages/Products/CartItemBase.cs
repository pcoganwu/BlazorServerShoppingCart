using BlazorServerShoppingCart.Web.Utilities;
using BlazorServerShoppingCart.Web.ViewModels;
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

        public string Text { get; set; } = "Your Cart is Empty";

        [Inject]
        public IProductViewModel _ProductViewModel { get; set; }

        [CascadingParameter]
        public CartStateProvider CartStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Check to see if a product is already in the Cart.
            //If product is in the cart, the quantity is updated
            int index = ItemInCart(CartStateProvider.ShoppingCart.Items, ProductId);

            if (index == -1)
            {
                ProductsItem item = new()
                {
                    ProductViewModel = await _ProductViewModel.GetOrderProduct(ProductId)
                };
                item.ProductViewModel.Quantity = Quantity;
                CartStateProvider.ShoppingCart.Items.Add(item);
                await CartStateProvider.SaveChangesAsync();
            }
            else
            {
                CartStateProvider.ShoppingCart.Items[index].ProductViewModel.Quantity += Quantity;
            }
        }


        protected async Task RemoveItemAsync()
        {
            int index = ItemInCart(CartStateProvider.ShoppingCart.Items, ProductId);

            if (index is -1)
            {
                index = 0;
            }

            //Remove the item from the Cart
            CartStateProvider.ShoppingCart.Items.RemoveAt(index);

            //Update the cart - save to local storage
            await CartStateProvider.SaveChangesAsync();
        }

        protected async Task ClearCartAsync()
        {
            //Remove all items from the shopping cart
            CartStateProvider.ShoppingCart.Items.Clear();

            //Update the cart - save to local storage
            await CartStateProvider.SaveChangesAsync();
        }

        private int ItemInCart(List<ProductsItem> cart, string id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductViewModel.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
