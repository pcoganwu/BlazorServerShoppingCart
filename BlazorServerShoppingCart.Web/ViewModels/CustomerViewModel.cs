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

        public CustomerViewModel()
        {

        }

        public CustomerViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Required, MaxLength(25), RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)
                                   |(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email Format")]
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

        //To convert Customer to CustomerViewModel
        private CustomerViewModel LoadCurrentObject(CustomerViewModel customerViewModel)
        {
            this.Email = customerViewModel.Email;
            this.LastName = customerViewModel.LastName;
            this.FirstName = customerViewModel.FirstName;
            this.Address = customerViewModel.Address;
            this.City = customerViewModel.City;
            this.State = customerViewModel.State;
            this.ZipCode = customerViewModel.ZipCode;
            this.PhoneNumber = customerViewModel.PhoneNumber;

            return customerViewModel;
        }

        public static implicit operator CustomerViewModel(Customer customer)
        {
            return new CustomerViewModel
            {
                Email = customer.Email,
                LastName = customer.LastName,
                FirstName = customer.FirstName,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                ZipCode = customer.ZipCode,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public static implicit operator Customer(CustomerViewModel customerViewModel)
        {
            return new CustomerViewModel
            {
                Email = customerViewModel.Email,
                LastName = customerViewModel.LastName,
                FirstName = customerViewModel.FirstName,
                Address = customerViewModel.Address,
                City = customerViewModel.City,
                State = customerViewModel.State,
                ZipCode = customerViewModel.ZipCode,
                PhoneNumber = customerViewModel.PhoneNumber
            };
        }
    }
}
