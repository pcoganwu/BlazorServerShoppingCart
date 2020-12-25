using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Customers
{
    public class CustomerListBase : ComponentBase
    {
        [Inject]
        public ICustomerViewModel CustomerViewModel { get; set; }

        protected IList<Customer> Customers { get; set; } = new List<Customer>();

        protected override async Task OnInitializedAsync()
        {
            Customers = await CustomerViewModel.GetAllCustomers();
        }
    }
}
