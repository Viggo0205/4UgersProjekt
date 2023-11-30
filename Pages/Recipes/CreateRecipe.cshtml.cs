using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _4UgersProjekt.Pages.Recipes
{
    public class CreateRecipeModel : PageModel
    {
        [BindProperty]
        public Models.Recipes Recipes { get; set; }

        private IRecipeService _recipeService;

        public CreateRecipeModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Recipes.Ingredients.Count == 0)
            {
                return Page();
            }

            _recipeService.Add(Recipes);
            return RedirectToPage("GetAllRecipes");
        }
    }
}

