using _4UgersProjekt.Models;
namespace _4UgersProjekt.Services
{
	public interface IIngredientService : IService<Ingredient>
	{
		public int GetCalories();
	}
}
