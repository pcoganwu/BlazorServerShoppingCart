using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Customers
{
    public class DeleteCustomerBase : ComponentBase
    {
        [Inject]
        public ICustomerViewModel CustomerViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Email { get; set; }

        protected Customer Customer { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Customer = await CustomerViewModel.GetCustomer(Email);
        }

        protected async Task Handle_SubmitAsync()
        {
            await CustomerViewModel.DeleteCustomer(Email);
            NavigationManager.NavigateTo("/customers/customerList");
        }
    }
}
