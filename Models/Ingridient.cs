namespace _4UgersProjekt.Models
{
	public class Ingridient
	{
		public enum IngredientType
		{
			Meat,
			Vegetables,
			Liquid,
			Spices
		}

		public Ingridient() { }

		public Ingridient(IngredientType engridientType, string name, int fatPct, int carbPct, int protPct, int calories)
		{
			Name = name;
			FatPct = fatPct;
			CarbPct = carbPct;
			ProtPct = protPct;
			Calories = calories;
		}

		public string Name
		{
			get;
		}
		public int FatPct
		{
			get;
		}
		public int CarbPct
		{
			get;
		}
		public int ProtPct
		{
			get;
		}

		public IngredientType IngredientT
		{
			get;
		}

		public int Calories
		{
			get;
		}
	}
}
