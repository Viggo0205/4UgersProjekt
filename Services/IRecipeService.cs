using _4UgersProjekt.Models;

namespace _4UgersProjekt.Services
{
    public interface IRecipeService:IService<Recipe>
    {
        List<RecipeComponent> GetIngredients();
		IEnumerable<Recipe> CalorieFilter(int maxCalories, int minCalories = 0);

	}
}
