using _4UgersProjekt.Models;
using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _4UgersProjekt.Pages.Recipes
{
	public class CreateCustomerModel : PageModel
	{
		[BindProperty]
		public Customer Customer { get; set; }

		private ICustomerService _customerService;

		public CreateCustomerModel(ICustomerService customerService)
		{
			_customerService = customerService;
		}
		public IActionResult OnGet()
		{
			return Page();
		}

        public IActionResult OnPost()
        {
            Console.WriteLine("OnPost method called in CreateCustomerModel");

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Model error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            _customerService.SetCurrentCustomer(Customer);
            _customerService.Add(Customer);

            Console.WriteLine("Before redirecting to GetAllCustomers");
            return RedirectToPage("/Recipes/GetAllCustomers");
        }
    }
}