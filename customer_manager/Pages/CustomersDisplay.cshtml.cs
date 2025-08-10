using customer_manager.Models;
using customer_manager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace customer_manager.Pages
{
    public class CustomersDisplayModel : PageModel
    {
        private readonly IRepository _repository;

        public CustomersDisplayModel(IRepository repository)
        {
            _repository = repository;
        }

        public List<Customer> Customers { get; private set; }

        public async Task OnGetAsync()
        {
            Customers = await _repository.GetCustomers();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var result = await _repository.DeleteCustomer(id);
            if (result > 0)
            {
                return RedirectToPage("/CustomersDisplay");
            }
            ModelState.AddModelError("", "Error deleting customer.");
            return Page();
        }

    }
}
