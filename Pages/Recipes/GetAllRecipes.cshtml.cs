using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _4UgersProjekt.Services;

namespace _4UgersProjekt.Pages.Recipes
{
    public class GetAllRecipesModel : PageModel
    {
        public List<Models.Recipe>? Recipes { get; private set; }

        [BindProperty]
        public string SearchString { get; set; }



        private IRecipeService _recipeService;

        public GetAllRecipesModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public IActionResult OnPostNameSearch()
        {
            Recipes = _recipeService.NameSearch(SearchString).ToList();
            return Page();
        }


        public void OnGet()
        {
            Recipes = _recipeService.Get();
        }
    }
}
