using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _4UgersProjekt.Pages.Recipes
{
    public class DeleteRecipesModel : PageModel
    {
           private IRecipeService _repo;

           public DeleteRecipesModel(IRecipeService repo)
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
               Models.Recipe? deletedRecipe = _repo.Delete(Recipe.Id);
               if (deletedRecipe == null)
                   return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

               return RedirectToPage("GetAllRecipes");
           }
    }
}
