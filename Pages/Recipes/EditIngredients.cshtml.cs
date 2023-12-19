using System;
using System.Collections.Generic;
using System.Linq;
using _4UgersProjekt.Models;
using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//Jonas
namespace _4UgersProjekt.Pages.Recipes
{
    public class EditIngredientModel : PageModel
    {
        private readonly IIngredientService _ingredientService;

        [BindProperty]
        public Ingredient Ingredient { get; set; }
		[BindProperty]
		public Ingredient.IngredientType ChosenIngredientType { get; set; }

		public EditIngredientModel(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult OnGet(int id)
        {
            Ingredient = _ingredientService.Get(id);

            if (Ingredient == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			Ingredient.IngredientT = ChosenIngredientType; // Set the IngredientT property

			_ingredientService.Update(Ingredient);

			return RedirectToPage("GetAllIngredients");
		}
	}
}
