using customer_manager.Models;
using customer_manager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace customer_manager.Pages
{
    public class CustomerDetailsModel : PageModel
    {
        private readonly IRepository _repository;

        public CustomerDetailsModel(IRepository repository)
        {
            _repository = repository;
        }

        public Customer? Customer { get; private set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _repository.GetById(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

