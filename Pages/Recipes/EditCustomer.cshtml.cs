using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _4UgersProjekt.Models;
using _4UgersProjekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
//Jonas
namespace _4UgersProjekt.Pages.Recipes
{
    public class EditCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IRecipeService _recipeService;

        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty]
        public List<int> MealPlanIdsMorning { get; set; } = new List<int>();

        [BindProperty]
        public List<int> MealPlanIdsNoon { get; set; } = new List<int>();

        [BindProperty]
        public List<int> MealPlanIdsEvening { get; set; } = new List<int>();

        [BindProperty]
        public List<bool> Favories { get; set; } = new List<bool>();

        public List<CreateCustomerModel.Weekday> WeekDays { get; set; }

        public SelectList RecipeSelectList { get; set; }

        public List<Recipe> Recipes { get; set; }

        public EditCustomerModel(ICustomerService customerService, IRecipeService recipeService)
        {
            _customerService = customerService;
            _recipeService = recipeService;
        }

        public IActionResult OnGet(int id)
        {
                Customer = _customerService.Get(id);

                if (Customer == null)
                {
                    return RedirectToPage("/NotFound");
                }

            // Initialize the selected favorites checkboxes
            // Favories = _recipeService.Get().Select(r => Customer.Favorites.Contains(r)).ToList();

            List<Recipe> recipes = _recipeService.Get();

            foreach (Recipe recipe in recipes)
            {
                Favories.Add(Customer.Favorites.Select(r => r.Id).Contains(recipe.Id));
            }

            // Initialize the selected recipe IDs for each day's meal plan
            for (int day = 0; day < 7; day++)
            {
                MealPlanIdsMorning.Add(Customer.MealPlans[(CreateCustomerModel.Weekday)day]?.Morning?.Id ?? 0);
                MealPlanIdsNoon.Add(Customer.MealPlans[(CreateCustomerModel.Weekday)day]?.Noon?.Id ?? 0);
                MealPlanIdsEvening.Add(Customer.MealPlans[(CreateCustomerModel.Weekday)day]?.Evening?.Id ?? 0);
            }

            // Populate the Recipes list
            Recipes = _recipeService.Get();

            // Initialize the SelectList for recipe dropdowns
            RecipeSelectList = new SelectList(Recipes, nameof(Recipe.Id), nameof(Recipe.Name));

            // Initialize the WeekDays list
            WeekDays = Enum.GetValues<CreateCustomerModel.Weekday>().ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the customer's favorites based on the selected checkboxes
            Customer.Favorites = _recipeService.Get().Where((r, index) => Favories[index]).ToList();

            // Update the customer's meal plans based on the selected recipe IDs
            for (int day = 0; day < 7; day++)
            {
                Customer.MealPlans[(CreateCustomerModel.Weekday)day].Morning = _recipeService.Get(MealPlanIdsMorning[day]);
                Customer.MealPlans[(CreateCustomerModel.Weekday)day].Noon = _recipeService.Get(MealPlanIdsNoon[day]);
                Customer.MealPlans[(CreateCustomerModel.Weekday)day].Evening = _recipeService.Get(MealPlanIdsEvening[day]);
            }

            _customerService.Update(Customer);

            return RedirectToPage("GetAllCustomers");
        }
    }
}
