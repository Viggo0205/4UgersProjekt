using _4UgersProjekt.Services;
using _4UgersProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _4UgersProjekt.Pages.Recipes
{
    public class CreateRecipeModel : PageModel
    {
       
        public List<Ingridient> Ingridients { get;}
		[BindProperty]
		public List<int> Amount { get;}    
        private IRecipeService _recipeService;

        public CreateRecipeModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;

            for(int i = 0; i<Ingridients.Count; i++)
            {
                Amount.Add(0);
            }
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Recipes _recipes = new Models.Recipes();

            for(int i = 0; i < Ingridients.Count; i++)
            {
                if (Amount[i] > 0)
                {
                    _recipes.Ingredients.Add(new RecipeComponent(Ingridients[i], Amount[i]));
                }
            }

            _recipeService.Add(_recipes);
            return RedirectToPage("GetAllRecipes");
        }
    }
}

