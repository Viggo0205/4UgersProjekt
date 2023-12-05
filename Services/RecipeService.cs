using _4UgersProjekt.Models;

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

		public override void Update(Recipe item)
        {
            if(item != null)
            {
                foreach(Recipe i in _data)
                {
                    if(i.Id == item.Id)
                    {
                        i.Name = item.Name;
                    }
                }
                _jsonFile.SaveJson(_data);
            }
        }

	}
}
