using _4UgersProjekt.Models;

namespace _4UgersProjekt.Services
{
    public class RecipeService : DataRepository<Recipes>, IRecipeService
    {
        public RecipeService(IWebHostEnvironment webHostEnvironment):base(new JSonFileRecipeService(webHostEnvironment)) 
        { 
            
        }
        public List<RecipeComponent> GetIngredients()
        {
			Recipes recipes = new Recipes();
			return recipes.Ingredients; 
        }

        public override void Update(Recipes item)
        {
            if(item != null)
            {
                foreach(Recipes i in _data)
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
