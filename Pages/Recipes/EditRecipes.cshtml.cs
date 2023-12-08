using _4UgersProjekt.Models;
using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _4UgersProjekt.Pages.Recipes
{
    public class EditRecipesModel : PageModel
	{
		private IRecipeService _repo;

		public EditRecipesModel(IRecipeService repo)
		{
			_repo = repo;
		}

		[BindProperty]
		public Models.Recipe Recipe { get; set; }

		public IActionResult OnGet(int id)
		{
			Models.Recipe? recipe = _repo.Get(id);

			if (recipe != null)
				Recipe = recipe;
			else
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_repo.Update(Recipe);
			return RedirectToPage("GetAllRecipes");
		}
	}
}
