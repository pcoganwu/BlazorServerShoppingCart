using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Utilities
{
    public class CartStateProviderBase : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public Cart ShoppingCart { get; set; } = new();

        public bool hasLoaded { get; set; } = false;

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await LocalStorage.GetAsync<Cart>("ShoppingCart");
            

            if (result.Success)
            {
                ShoppingCart = result.Value;
            }
            else
            {
                ShoppingCart = null;
            }

            if(ShoppingCart == null || ShoppingCart.Items.Count == 0)
            {
                //Create a new Cart
                ShoppingCart = new Cart();
            }
            else
            {
                //Check if the Cart item in the Local storage has expired
                if(DateTime.Now > ShoppingCart.LastTimeSaved.AddMinutes(ShoppingCart.LengthOfTimeInStorage))
                {
                    //if expired create a new Cart.
                    ShoppingCart = new Cart();
                }
            }
            //Update time the item was saved to the current time.
            ShoppingCart.LastTimeSaved = DateTime.Now;
            hasLoaded = true;
        }

        public async Task SaveChangesAsync()
        {
            //Saves the item to the local storage
            ShoppingCart.LastTimeSaved = DateTime.Now;
            await LocalStorage.SetAsync("ShoppingCart", ShoppingCart);
        }
    }
}
