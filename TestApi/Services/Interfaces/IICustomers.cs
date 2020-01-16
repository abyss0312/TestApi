using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Domain;

namespace TestApi.Services.Interfaces
{
    public interface IICustomers
    {
        Task<List<Customers>> GetCustomersAsync();

        Task<Customers> GetCustomerByIdAsync(int customerId);
        Task<bool> CreateCustomerAsync(Customers customer);

        Task<bool> UpdateCustomerAsync(Customers customer);

        Task<bool> DeleteCustomerAsync(int customerId);
    }
}
