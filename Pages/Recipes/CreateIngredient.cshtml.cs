using _4UgersProjekt.Models;
using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _4UgersProjekt.Pages.Recipes
{
    public class CreateIngredientModel : PageModel
    {
		[BindProperty]
		public  Ingredient Ingredient { get; set; }

		private IIngredientService _ingredientService;

		public CreateIngredientModel(IIngredientService ingredientService)
		{
			_ingredientService = ingredientService;
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

			_ingredientService.Add(Ingredient);
			Console.WriteLine("Cunt");
			return RedirectToPage("GetAllIngredients");
		}
	}
}
