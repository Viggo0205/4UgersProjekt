namespace _4UgersProjekt.Models
{
	public class RecipeComponent
	{
		public Ingredient Ingredient { get; set; }
		public int Amount { get; set; }

		public RecipeComponent() {  }

		public RecipeComponent(Ingredient ingredient,int amount) 
		{ 
			Ingredient = ingredient;
			Amount = amount;
		}

		public override string ToString()
		{
			return $"Name: {Ingredient?.Name}, Amount: {Amount} ";
		}
	}
}
