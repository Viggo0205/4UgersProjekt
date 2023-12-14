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
		public int MinCalories { get; set; }
		[BindProperty]
		public int MaxCalories { get; set; }
		[BindProperty]
		public string SearchType { get; set; }
		[BindProperty]
		public GoalType GoalType { get; set; }
		[BindProperty]
		public ToolType ToolType { get; set; }
		[BindProperty]
		public bool IsOven { get; set; }
		[BindProperty]
		public bool IsMicrowave { get; set; }
		[BindProperty]
		public bool IsPan { get; set; }
		[BindProperty]
		public bool Lactose { get; set; }

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

		public IActionResult OnPostCalorieFilter()
		{
			Recipes = _recipeService.CalorieFilter(MaxCalories, MinCalories).ToList();
			return Page();
		}
		public IActionResult OnPostGoalFilter()
		{
			Recipes = _recipeService.GoalFilter(GoalType).ToList();
			return Page();
		}
		public IActionResult OnPostToolFilter()
		{
			List<ToolType> ChosenTools = new List<ToolType>();

			if (IsOven)
			{
				ChosenTools.Add(ToolType.Oven);
			}

			if (IsMicrowave)
			{
				ChosenTools.Add(ToolType.Microwave);
			}

			if (IsPan)
			{
				ChosenTools.Add(ToolType.Pan);

			}

			if (!IsOven && !IsMicrowave && !IsPan)
			{
				ChosenTools.AddRange(Enum.GetValues(typeof(ToolType)).Cast<ToolType>()); // 
			}
			Recipes = _recipeService.ToolFilter(ChosenTools).ToList();
			return Page();
		}
		public IActionResult OnPostLactoseFilter()
		{
			if (Lactose)
				Recipes = _recipeService.LactoseFilter().ToList();
			else
				Recipes = _recipeService.Get();

			return Page();
		}


		public void OnGet()
        {
            Recipes = _recipeService.Get();
        }
	}
}
