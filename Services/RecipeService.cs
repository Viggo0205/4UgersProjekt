﻿using _4UgersProjekt.Models;
using System.Linq;

//Jonas, Matti og Tobias
namespace _4UgersProjekt.Services
{
    public class RecipeService : DataRepository<Recipe>, IRecipeService
    {
		Recipe _recipes = new Recipe();
		public RecipeService(IWebHostEnvironment webHostEnvironment):base(new JSonFileRecipeService(webHostEnvironment)) 
        { 
            
        }
        public List<RecipeComponent> GetIngredients()
        {
			Recipe recipes = new Recipe();
			return recipes.Ingredients;
        }

		public IEnumerable<Recipe> GoalFilter(GoalType goalType)
		{
			List<Recipe> filterList = new List<Recipe>();
			foreach (Recipe item in _data)
			{

				if ( item.GoalT == goalType) 
				{ 
					filterList.Add(item);
				}
			}
			return filterList;
		}

		public IEnumerable<Recipe> ToolFilter(List<ToolType> toolType)
		{
			List<Recipe> filterListTool = new List<Recipe>();
			foreach (Recipe item in _data)
			{
				
				if (toolType.Contains(item.ToolT))
				{
					filterListTool.Add(item);
				}
			}
			return filterListTool;
		}
		public IEnumerable<Recipe> CalorieFilter(int maxCalories, int minCalories = 0)
		{
			List<Recipe> filterList = new List<Recipe>();
			foreach (Recipe item in _data)
			{
    
				
				if ((minCalories == 0 && item.TotalCalories <= maxCalories) ||
					(maxCalories == 0 && item.TotalCalories >= minCalories) ||
					(item.TotalCalories >= minCalories && item.TotalCalories <= maxCalories))
				{
                    Console.WriteLine("Cool Stuff");
					filterList.Add(item);
                    
				}
			}

			return filterList;
		}


		public IEnumerable<Recipe> LactoseFilter()
		{
			List<Recipe> filterList = new List<Recipe>();

			foreach (Recipe r in _data)
			{
				bool hasLactose = false;

				foreach (RecipeComponent rc in r.Ingredients)
				{
					if (Recipe.LactoseList.Contains(rc.Ingredient.Name.ToLower()))
						hasLactose = true;
				}

				if (!hasLactose)
					filterList.Add(r);
			}

			return filterList;
		}


		public override void Update(Recipe updatedRecipe)
        {
            if (updatedRecipe != null)
            {
                Recipe existingRecipe = _data.FirstOrDefault(r => r.Id == updatedRecipe.Id);

                if (existingRecipe != null)
                {
                    existingRecipe.Name = updatedRecipe.Name;
                    existingRecipe.Ingredients.Clear();
                    foreach (RecipeComponent updatedComponent in updatedRecipe.Ingredients)
                    {

                            existingRecipe.Ingredients.Add(updatedComponent);
                        
                    }

                    _jsonFile.SaveJson(_data);
                }
            }
        }
        public List<Recipe> SearchByIngredientName(string ingredientName)
		{
			return _data
		.Where(recipe =>
			recipe.Ingredients.Any(component =>
				component.Ingredient != null &&  
				component.Ingredient.Name != null &&  
				component.Ingredient.Name.ToLower().Contains(ingredientName?.ToLower() ?? "")
			)
		)
		.ToList();
		}

	}
}
