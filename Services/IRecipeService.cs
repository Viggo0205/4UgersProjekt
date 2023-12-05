using _4UgersProjekt.Models;

namespace _4UgersProjekt.Services
{
    public interface IRecipeService:IService<Recipe>
    {
        List<RecipeComponent> GetIngredients();
    }
}
