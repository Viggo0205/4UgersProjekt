using _4UgersProjekt.Models;

namespace _4UgersProjekt.Services
{
    public class RecipeService : DataRepository<Recipe>, IRecipeService
    {
        public RecipeService(IWebHostEnvironment webHostEnvironment):base(new JSonFileRecipeService(webHostEnvironment)) 
        { 
            
        }
        public List<RecipeComponent> GetIngredients()
        {
			Recipe recipes = new Recipe();
			return recipes.Ingredients;
        }

        public override void Update(Recipe item)
        {
            if (item != null)
            {
                foreach (Recipe i in _data)
                {
                    if (i.Id == item.Id)
                    {
                        i.Name = item.Name;
                    }
                }
                _jsonFile.SaveJson(_data);
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
