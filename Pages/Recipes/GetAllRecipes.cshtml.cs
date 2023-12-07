using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _4UgersProjekt.Services;
using _4UgersProjekt.Models;

namespace _4UgersProjekt.Pages.Recipes
{
    public class GetAllRecipesModel : PageModel
    {
        public List<Models.Recipe>? Recipes { get; private set; }
		public List<Models.Ingredient>? Ingredients { get; private set; }
        [BindProperty]
        public string SearchString { get; set; }
		[BindProperty]
		public string SearchType { get; set; }


		private IRecipeService _recipeService;
		private IIngredientService _ingredientService;
		public GetAllRecipesModel(IRecipeService recipeService, IIngredientService ingredientService)
        {
            _recipeService = recipeService;
            _ingredientService = ingredientService;

		}
		public IActionResult OnPost()
		{
			if (!string.IsNullOrEmpty(SearchType))
			{
				if (SearchType.Equals("NameSearch", StringComparison.OrdinalIgnoreCase))
				{
					Recipes = _recipeService.NameSearch(SearchString).ToList();
				}
				else if (SearchType.Equals("IngredientSearch", StringComparison.OrdinalIgnoreCase))
				{
					Recipes = _recipeService.SearchByIngredientName(SearchString).ToList();
				}
			}
			else
			{
				// Handle the case where neither button was clicked
				Recipes = _recipeService.Get();
			}

			return Page();
		}

		public IActionResult OnPostNameSearch()
        {
            Recipes = _recipeService.NameSearch(SearchString).ToList();
            return Page();
        }
        public IActionResult OnPostIngredientSearch()
        {
            Recipes = _recipeService.SearchByIngredientName(SearchString).ToList();
            return Page();
        }

        public void OnGet()
        {
            Recipes = _recipeService.Get();
        }
    }
}
