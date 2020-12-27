using BlazorServerShoppingCart.Models.Domain;
using BlazorServerShoppingCart.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Pages.Customers
{
    public class EditCustomerBase : ComponentBase
    {
        [Parameter]
        public string Email { get; set; }
        [Inject]
        public ICustomerViewModel CustomerViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IStateViewModel StateViewModel { get; set; }

        protected string PageTitle { get; set; } = string.Empty;

        protected string ButtonText { get; set; } = string.Empty;

        protected string CustomerAdded { get; set; } = string.Empty;

        protected Customer Customer { get; set; } = new();

        protected IList<State> States { get; set; } = new List<State>();

        protected override async Task OnInitializedAsync()
        {
            if (Email is null)
            {
                PageTitle = "Add a New Customer";
                ButtonText = "ADD";
                States = await StateViewModel.GetAllStates();
                Customer = new Customer();
            }
            else
            {
                States = await StateViewModel.GetAllStates();
                Customer = await CustomerViewModel.GetCustomer(Email);
                PageTitle = $"Updating {Customer.FirstName} {Customer.LastName}";
                ButtonText = "Update";
            }
           
        }

        protected async Task Handle_SubmitAsync()
        {
            if (Email is null)
            {
                CustomerAdded = $"Customer {Customer.FirstName} {Customer.LastName} sucessfully added.";
                await CustomerViewModel.AddCustomer(Customer);
                NavigationManager.NavigateTo($"/customers/customerList/{CustomerAdded}");
            }
            else
            {
                CustomerAdded = $"Customer {Customer.FirstName} {Customer.LastName} sucessfully updated.";
                await CustomerViewModel.UpdateCustomer(Customer);
                NavigationManager.NavigateTo($"/customers/customerList/{CustomerAdded}");
            }
        }
    }
}
