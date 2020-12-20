using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Utilities
{
    public class Cart
    {
        public List<ProductsItem> Items { get; set; } = new();

        public decimal Total
        {
            get 
            {
                decimal total = 0.0m;
                foreach(var item in Items)
                {
                    total += item.Total;
                }
                return total;
            }
        }

        //To check the last time localStorage was accessed
        public DateTime LastAccessed { get; set; }

        //Time in minutes to persist the cart in localStorage (cart has expired)
        public int TimeToLiveInMinutes { get; set; } = 5; // default
    }
}
