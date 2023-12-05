using _4UgersProjekt.Models;

namespace _4UgersProjekt.Services
{
    public class JSonFileRecipeService : JsonFileService<Recipe>
    {

        public JSonFileRecipeService(IWebHostEnvironment webHostEnvironment) 
            : base(webHostEnvironment) 
        {
        }

        protected override string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Recipes.json"); }
        }
    }
}
