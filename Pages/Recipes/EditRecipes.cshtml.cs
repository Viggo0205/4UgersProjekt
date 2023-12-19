using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _4UgersProjekt.Models;
using _4UgersProjekt.Services;
using System.Diagnostics.Eventing.Reader;
using System.Timers;
//Jonas
namespace _4UgersProjekt.Pages.Recipes
{
    public class EditRecipesModel : PageModel
    {
        private IRecipeService _repo;
        public EditRecipesModel(IRecipeService repo, IIngredientService ingredientService)
        {
            _repo = repo;
            Ingredients = ingredientService.Get();
            Amount = new List<int>();
           
            for (int i = 0; i < Ingredients.Count; i++)
            
            {
                Amount.Add(0);
            }
        }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public Models.Recipe Recipe { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        [BindProperty]
        public List<int> Amount { get; }

        public IActionResult OnGet(int id)
        {
            Models.Recipe? recipe = _repo.Get(id);

            if (recipe != null)
            {

                Recipe = recipe;
                for (int i = 0; i < Ingredients.Count; i++) 
                {
                    Amount[i] = recipe.getCount(Ingredients[i].Id);
                }

            }
            else
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Recipe updatedRecipe = new Models.Recipe
            {
                Id = Recipe.Id,
                Name = Recipe.Name
            };

            for (int i = 0; i < Ingredients.Count; i++)
            {
                Console.WriteLine($"Processing Ingredient: {Ingredients[i].Name}, Amount: {Amount[i]}");

                if (Amount[i] > 0)
                {
                    updatedRecipe.Ingredients.Add(new RecipeComponent
                    {
                        Ingredient = Ingredients[i],
                        Amount = Amount[i]
                    });
                }
              
            }


            _repo.Update(updatedRecipe);
            return RedirectToPage("GetAllRecipes");
        }
    }
}
