using customer_manager.Models;
using customer_manager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace customer_manager.Pages
{
    public class AddCustomerModel : PageModel
    {
        private readonly IRepository _repository;

        public AddCustomerModel(IRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public CustomerView ViewModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (id.HasValue)
            {
                var customer = await _repository.GetById(id.Value);

                ViewModel = new CustomerView
                {
                    FName = customer.FName,
                    LName = customer.LName,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    CompanyName = customer.CompanyName,
                    Notes = customer.Notes
                };
            }
            else
            {
                ViewModel = new CustomerView();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool success = false;

            if (id.HasValue)
            {
                var binding = new CustomerBinding
                {
                    FName = ViewModel.FName,
                    LName = ViewModel.LName,
                    Email = ViewModel.Email,
                    Phone = ViewModel.Phone,
                    Address = ViewModel.Address,
                    CompanyName = ViewModel.CompanyName,
                    Notes = ViewModel.Notes
                };

                var updateResult = await _repository.UpdateCustomer(id.Value, binding);
                success = updateResult > 0;
            }
            else
            {
                var binding = new CustomerBinding
                {
                    FName = ViewModel.FName,
                    LName = ViewModel.LName,
                    Email = ViewModel.Email,
                    Phone = ViewModel.Phone,
                    Address = ViewModel.Address,
                    CompanyName = ViewModel.CompanyName,
                    Notes = ViewModel.Notes
                };

                var addResult = await _repository.AddCustomer(binding);
                success = addResult > 0;
            }

            if (success)
            {
                return RedirectToPage("/CustomersDisplay");
            }

            ModelState.AddModelError("", "Error saving customer.");
            return Page();
        }


    }
}

