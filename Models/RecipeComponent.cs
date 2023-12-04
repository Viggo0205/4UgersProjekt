namespace _4UgersProjekt.Models
{
	public class RecipeComponent
	{
		public Ingredient Ingridient { get; set; }
		public int Amount { get; set; }

		public RecipeComponent() { }

		public RecipeComponent(Ingredient ingridient,int amount) 
		{ 
			Ingridient = ingridient;
			Amount = amount;
		}
	}
}
