using _4UgersProjekt.Models;
//Victor
namespace _4UgersProjekt.Services
{
	public interface IIngredientService : IService<Ingredient>
	{
		public int GetCalories();
	}
}
