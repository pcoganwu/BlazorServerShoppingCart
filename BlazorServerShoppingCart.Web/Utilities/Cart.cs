using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Utilities
{
    public class Cart
    {
        public List<ProductsItem> Items { get; set; } = new();


        //This is the running total cost of items in a Cart
        public decimal Total
        {
            get 
            {
                decimal total = 0.0m;
                foreach(var item in Items)
                {
                    total += item.Cost;
                }
                return total;
            }
        }

        //To check the last time localStorage was accessed
        //whenever the Cart is persisted to the storage, the last accessed time is saved.
        public DateTime LastTimeSaved { get; set; }

        //Time in minutes to persist the cart in localStorage (cart has expired)
        //When loading the cart from local storage, a check is made to see if the cart
        //has expired based on LastTimeSaved and LengthOfTimeInStorage properties.
        public int LengthOfTimeInStorage { get; set; } = 5; // default
    }
}
