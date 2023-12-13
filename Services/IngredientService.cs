using _4UgersProjekt.Models;
using Microsoft.AspNetCore.Hosting;

namespace _4UgersProjekt.Services
{
	public class IngredientService : DataRepository<Ingredient>, IIngredientService
	{
		public IngredientService(IWebHostEnvironment webHostEnvironment) : base(new JSonFileIngredientService(webHostEnvironment))
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
						i.IngredientT = item.IngredientT; // Update the IngredientT property
					}
				}
				_jsonFile.SaveJson(_data);
			}
		}
	}
}
