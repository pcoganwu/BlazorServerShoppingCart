using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public interface ICustomerRepository
    {
        Task<IList<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(string email);
        Task<Customer> AddCustomer(Customer newCustomer);
        Task<Customer> UpdateCustomer(Customer updatedCustomer);
        Task<Customer> DeleteCustomer(string email);
    }
}
