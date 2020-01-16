using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Data;
using TestApi.Domain;
using TestApi.Services.Interfaces;

namespace TestApi.Services
{
    public class CustomerServices : IICustomers
    {
        private readonly DataContext _dbservice;

        public CustomerServices(DataContext dbservice)
        {
            _dbservice = dbservice;
        }
        public async Task<bool> CreateCustomerAsync(Customers customer)
        {
            await _dbservice.Customers.AddAsync(customer);
            var created = await _dbservice.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var deletedCustomer = await GetCustomerByIdAsync(customerId);
            _dbservice.Customers.Remove(deletedCustomer);
            var deleted = await _dbservice.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Customers> GetCustomerByIdAsync(int customerId)
        {
            return await _dbservice.Customers.SingleOrDefaultAsync(x => x.CustomerId == customerId);
        }

        public async Task<List<Customers>> GetCustomersAsync()
        {
            return await _dbservice.Customers.ToListAsync();
        }

        public async Task<bool> UpdateCustomerAsync(Customers customer)
        {
            _dbservice.Customers.Update(customer);
            var updated = await _dbservice.SaveChangesAsync();
            return updated > 0;
        }
    }
}
