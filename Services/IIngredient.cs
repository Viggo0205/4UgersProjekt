using _4UgersProjekt.Models;
namespace _4UgersProjekt.Services
{
	public interface IIngredient : IService<Ingredient>
	{
		public int GetCalories();
	}
}
