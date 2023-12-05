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
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_customerService.Add(Customer);
			return RedirectToPage("GetAllCustomers");
		}
	}
}