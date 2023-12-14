using _4UgersProjekt.Services;
using _4UgersProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace _4UgersProjekt.Pages.Recipes
{
    public class CreateRecipeModel : PageModel
    {
		[BindProperty]
		public string Name { get; set; }
		[BindProperty]
		public int Id { get; set; }

		[BindProperty]
		public Recipe Recipe { get; set; }

		[BindProperty]
		public GoalType ChosenGoalType { get; set; }

		[BindProperty]
		public ToolType ChosenToolType  { get; set; }

		public List<Ingredient> Ingredients { get;}
		[BindProperty]
		public List<int> Amount { get;}    
        private IRecipeService _recipeService;

        public CreateRecipeModel(IRecipeService recipeService, IIngredientService ingredientService)
        {
            _recipeService = recipeService;
            Ingredients = ingredientService.Get();
            Amount = new List<int>();
            for(int i = 0; i<Ingredients.Count; i++)
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
            Models.Recipe _recipes = new Models.Recipe(Id,Name);

			_recipes.GoalT = ChosenGoalType;

            _recipes.ToolT = ChosenToolType;
		
			for (int i = 0; i < Ingredients.Count; i++)
            {
                if (Amount[i] > 0)
                {
                    _recipes.Ingredients.Add(new RecipeComponent(Ingredients[i], Amount[i]));
                }
            }

            _recipeService.Add(_recipes);
            return RedirectToPage("GetAllRecipes");
        }
    }
}

