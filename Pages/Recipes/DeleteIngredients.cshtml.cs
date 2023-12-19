using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//Jonas
namespace _4UgersProjekt.Pages.Recipes
{
    public class DeleteIngredientsModel : PageModel
    {
		private IIngredientService _repo;

		public DeleteIngredientsModel(IIngredientService repo)
		{
			_repo = repo;
		}

		[BindProperty]
		public Models.Ingredient Ingredient { get; set; }


		public IActionResult OnGet(int id)
		{
			Models.Ingredient? ingredient = _repo.Get(id);

			if (ingredient != null)
				Ingredient = ingredient;
			else
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return Page();
		}

		public IActionResult OnPost()
		{
			Models.Ingredient? deletedIngredient = _repo.Delete(Ingredient.Id);
			if (deletedIngredient == null)
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return RedirectToPage("GetAllIngredients");
		}
	}
}
