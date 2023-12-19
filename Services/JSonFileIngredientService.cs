using _4UgersProjekt.Models;
//Victor
namespace _4UgersProjekt.Services
{
	public class JSonFileIngredientService : JsonFileService<Ingredient>
	{
		public JSonFileIngredientService(IWebHostEnvironment webHostEnvironment)
				: base(webHostEnvironment)
		{
		}

		protected override string JsonFileName
		{
			get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Ingredient.json"); }
		}
	}
}
