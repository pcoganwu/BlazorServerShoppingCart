using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.ViewModels
{
    public interface ICustomerViewModel
    {
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }

        State StateNavigation { get; set; }
        ICollection<Invoice> Invoices { get; set; }

        Task<IList<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(string email);
        Task<Customer> AddCustomer(Customer newCustomer);
        Task<Customer> UpdateCustomer(Customer updatedCustomer);
        Task DeleteCustomer(string email);
    }
}
