using BlazorServerShoppingCart.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Customer> AddCustomer(Customer newCustomer)
        {
            var customer = await _appDbContext.Customers.AddAsync(newCustomer);
            await _appDbContext.SaveChangesAsync();
            return customer.Entity;
        }

        public async Task<Customer> DeleteCustomer(string email)
        {
            //Find the customer to delete
            var customer = await _appDbContext.Customers.FirstOrDefaultAsync(c => c.Email == email);
            if (customer != null)
            {
                _appDbContext.Customers.Remove(customer);
                await _appDbContext.SaveChangesAsync();
                //return the deleted customer
                return customer;
            }
            return null;
        }

        public async Task<IList<Customer>> GetAllCustomers()
        {
            return await _appDbContext.Customers.Include(s => s.StateNavigation).ToListAsync();
        }

        public async Task<Customer> GetCustomer(string email)
        {
            return await _appDbContext.Customers.Include(s => s.StateNavigation).FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Customer> UpdateCustomer(Customer updatedCustomer)
        {
            //Find the customer to update
            var customer = await _appDbContext.Customers.FirstOrDefaultAsync(c => c.Email == updatedCustomer.Email);
            if (customer != null)
            {
                //Update the customer with the incoming customer object
                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.Address = updatedCustomer.Address;
                customer.City = updatedCustomer.City;
                customer.State = updatedCustomer.State;
                customer.ZipCode = updatedCustomer.ZipCode;
                customer.PhoneNumber = updatedCustomer.PhoneNumber;

                await _appDbContext.SaveChangesAsync();
                //return the updated customer
                return customer;
            }
            return null;
        }
    }
}
