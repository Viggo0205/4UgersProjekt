using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _4UgersProjekt.Pages.Recipes
{
    public class GetAllIngredientsModel : PageModel
    {
		public List<Models.Ingredient>? Ingredients { get; private set; }

		[BindProperty]
		public string SearchString { get; set; }



		private IIngredientService _ingredientService;

		public GetAllIngredientsModel(IIngredientService ingredientService)
		{
			_ingredientService = ingredientService;
		}

		public IActionResult OnPostNameSearch()
		{
			Ingredients = _ingredientService.NameSearch(SearchString).ToList();
			return Page();
		}


		public void OnGet()
		{
			Ingredients = _ingredientService.Get();
		}
	}
}
