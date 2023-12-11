using _4UgersProjekt.Models;
using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _4UgersProjekt.Pages.Recipes
{
	public class CreateCustomerModel : PageModel
	{
		[BindProperty]
		public Customer Customer { get; set; }

        public List<Recipe> Recipes { get; set; }   = new List<Recipe>();

        [BindProperty]
        public List<bool> Favories { get; set; } = new List<bool>();

		private ICustomerService _customerService;
        private IRecipeService _recipeService;

        [BindProperty]
		public List<int> MealPlanIdsMorning { get; set; } = new List<int>();

		[BindProperty]
		public List<int> MealPlanIdsNoon { get; set; } = new List<int>();

		[BindProperty]
		public List<int> MealPlanIdsEvening { get; set; } = new List<int>();

		public CreateCustomerModel(ICustomerService customerService, IRecipeService recipeService)
		{
			_customerService = customerService;
            _recipeService = recipeService;

			Recipes = _recipeService.Get();

            RecipeSelectList = new SelectList(Recipes, nameof(Recipe.Id), nameof(Recipe.Name));
		}

        public enum Weekday
        {
            Monday,
            Tuesday,
            Wedensday, 
            Thursday,
            Friday,
            Saturday,
            Sunday,
        }

        public List<Weekday> WeekDays { get { return Enum.GetValues<Weekday>().ToList(); } }

        public SelectList RecipeSelectList { get; set; }

        public class DailyMealPlan
        {
            public Recipe? Morning { get; set; }
			public Recipe? Noon { get; set; }
			public Recipe? Evening { get; set; }

		}
		public IActionResult OnGet()
		{
            Favories = new List<bool>();
            for (int i = 0; i < Recipes.Count; i++)
            {
                Favories.Add(false);
            }

			for (int i = 0; i < 7; i++)
			{
				MealPlanIdsMorning.Add(0);
				MealPlanIdsNoon.Add(0);
				MealPlanIdsEvening.Add(0);
			}

			return Page();
		}

        public IActionResult OnPost()
        {
            Recipes = _recipeService.Get();

            Console.WriteLine("OnPost method called in CreateCustomerModel");

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Model error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            for (int index = 0; index < Recipes.Count; index++)
            {
                if (Favories[index])
                {
                    Customer.Favorites.Add(Recipes[index]);
                }
            }

			for (int day = 0; day < 7; day++)
			{
                if (MealPlanIdsMorning[day] != 0)
                {
					Customer.MealPlans[(Weekday)day].Morning = _recipeService.Get(MealPlanIdsMorning[day]);
				}

				if (MealPlanIdsNoon[day] != 0)
				{
					Customer.MealPlans[(Weekday)day].Noon = _recipeService.Get(MealPlanIdsNoon[day]);
				}

				if (MealPlanIdsEvening[day] != 0)
				{
					Customer.MealPlans[(Weekday)day].Evening = _recipeService.Get(MealPlanIdsEvening[day]);
				}
			}

			_customerService.Add(Customer);

			Console.WriteLine("Before redirecting to GetAllCustomers");
            return RedirectToPage("/Recipes/GetAllCustomers");
        }
    }
}