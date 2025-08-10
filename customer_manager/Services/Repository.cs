using customer_manager.Data;
using customer_manager.Models;
using Microsoft.EntityFrameworkCore;

namespace customer_manager.Services
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _Context;
        public Repository(AppDbContext context)
        {
            _Context = context;

        }
        public async Task<int> AddCustomer(CustomerBinding bindingModel)
        {
            var customer = new Customer
            {
                FName = bindingModel.FName,
                LName = bindingModel.LName,
                Email = bindingModel.Email,
                Phone = bindingModel.Phone,
                Address = bindingModel.Address,
                CompanyName = bindingModel.CompanyName,
                Notes = bindingModel.Notes,
                CreatedAt = DateTime.Now
            };
            _Context.Customers.Add(customer);
            await _Context.SaveChangesAsync();
            return customer.CustomerId;
        }

        public async Task<Customer> GetById(int Id)
        {
            return await _Context.Customers.FindAsync(Id);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _Context.Customers.ToListAsync();

        }

        public async Task<int> UpdateCustomer(int Id, CustomerBinding bindingModel)
        {
            var customer = await _Context.Customers.FindAsync(Id);
            if (customer == null)
            {
                return 0; // Not found
            }
            customer.FName = bindingModel.FName;
            customer.LName = bindingModel.LName;
            customer.Email = bindingModel.Email;
            customer.Phone = bindingModel.Phone;
            customer.Address = bindingModel.Address;
            customer.CompanyName = bindingModel.CompanyName;
            customer.Notes = bindingModel.Notes;
            _Context.Customers.Update(customer);
            await _Context.SaveChangesAsync();
            return customer.CustomerId;
        }
        public async Task<int> DeleteCustomer(int Id)
        {
            var customer = await _Context.Customers.FindAsync(Id);
            if (customer == null)
            {
                return 0;
            }
            _Context.Customers.Remove(customer);
            return await _Context.SaveChangesAsync();
        }
    }
}
