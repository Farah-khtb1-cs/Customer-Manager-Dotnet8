using customer_manager.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace customer_manager.Services
{
    public interface IRepository
    {
        public Task<int> AddCustomer(CustomerBinding bindingModel);
        public Task<Customer> GetById(int Id);
        public Task<List<Customer>> GetCustomers();
        public Task<int> UpdateCustomer(int Id, CustomerBinding bindingModel);

        public Task<int> DeleteCustomer(int Id);

    }
}
