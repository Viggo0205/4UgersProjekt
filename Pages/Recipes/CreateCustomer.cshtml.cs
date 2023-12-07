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

        public List<Recipe> Recipes { get; set; }   = new List<Recipe>();

        [BindProperty]
        public List<bool> Favories { get; set; } = new List<bool>();

		private ICustomerService _customerService;
        private IRecipeService _recipeService;

		public CreateCustomerModel(ICustomerService customerService, IRecipeService recipeService)
		{
			_customerService = customerService;
            _recipeService = recipeService;
		}
		public IActionResult OnGet()
		{
            Recipes = _recipeService.Get();

            Favories = new List<bool>();
            for (int i = 0; i < Recipes.Count; i++)
            {
                Favories.Add(false);
            }

			return Page();
		}

        public IActionResult OnPost()
        {
            Recipes = _recipeService.Get();

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

            for (int index = 0; index < Recipes.Count; index++)
            {
                if (Favories[index])
                {
                    Customer.Favorites.Add(Recipes[index]);
                }
            }

            _customerService.SetCurrentCustomer(Customer);
            _customerService.Add(Customer);

            Console.WriteLine("Before redirecting to GetAllCustomers");
            return RedirectToPage("/Recipes/GetAllCustomers");
        }
    }
}