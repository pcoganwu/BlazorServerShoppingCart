using BlazorServerShoppingCart.Models.Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.ViewModels
{
    public class CustomerViewModel : ICustomerViewModel
    {
        private readonly HttpClient _httpClient;

        public CustomerViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Required, MaxLength(25)]
        public string Email { get; set; }
        [Required, MaxLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, MaxLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(40)]
        public string Address { get; set; }
        [Required, MaxLength(30)]
        public string City { get; set; }
        [Required, MaxLength(2)]
        public string State { get; set; }
        [Required, MaxLength(9), Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required, MaxLength(20), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public State StateNavigation { get; set; }
        public ICollection<Invoice> Invoices { get; set; }


        public async Task<Customer> AddCustomer(Customer newCustomer)
        {
            return await _httpClient.PostJsonAsync<Customer>("api/customers", newCustomer);
        }

        public async Task DeleteCustomer(string email)
        {
            await _httpClient.DeleteAsync($"api/customers/{email}");
        }

        public async Task<IList<Customer>> GetAllCustomers()
        {
            return await _httpClient.GetJsonAsync<List<Customer>>("api/customers");
        }

        public async Task<Customer> GetCustomer(string email)
        {
            return await _httpClient.GetJsonAsync<Customer>($"api/customers/{email}");
        }

        public async Task<Customer> UpdateCustomer(Customer updatedCustomer)
        {
            return await _httpClient.PutJsonAsync<Customer>("api/customers", updatedCustomer);
        }
    }
}
