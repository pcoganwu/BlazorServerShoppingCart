using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Customers
{
    public class CustomerDetailBase : ComponentBase
    {
        [Inject]
        public ICustomerViewModel CustomerViewModel { get; set; }

        [Parameter]
        public string Email { get; set; }

        public Customer Customer { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Customer = await CustomerViewModel.GetCustomer(Email);
        }
    }
}
