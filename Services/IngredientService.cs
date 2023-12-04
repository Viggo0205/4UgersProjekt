using _4UgersProjekt.Models;

namespace _4UgersProjekt.Services
{
	public class IngredientService : DataRepository<Ingredient>, IIngredient
	{
		public IngredientService(JsonFileService<Ingredient> jsonFile) : base(jsonFile)
		{
		}

		public int GetCalories()
		{
			Ingredient ingredient = new Ingredient();
			return ingredient.Calories;
		}

		public override void Update(Ingredient item)
		{
			if (item != null)
			{
				foreach (Ingredient i in _data)
				{
					if (i.Id == item.Id)
					{
						i.Name = item.Name;
					}
				}
				_jsonFile.SaveJson(_data);
			}
		}
	}
}
