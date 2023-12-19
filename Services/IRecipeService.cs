using _4UgersProjekt.Models;
//Matti og Tobias
namespace _4UgersProjekt.Services
{
    public interface IRecipeService : IService<Recipe>
    {
        List<RecipeComponent> GetIngredients();
		IEnumerable<Recipe> CalorieFilter(int maxCalories, int minCalories = 0);
        List<Recipe> SearchByIngredientName(string ingredientName);
		IEnumerable<Recipe> GoalFilter(GoalType goalType);
		IEnumerable<Recipe> ToolFilter( List<ToolType> toolTypes);
		IEnumerable<Recipe> LactoseFilter();

	}
}


