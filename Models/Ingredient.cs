using _4UgersProjekt.Services;
using System.ComponentModel.DataAnnotations;

namespace _4UgersProjekt.Models
{
	public class Ingredient : IHaveIdAndName
	{
		public enum IngredientType
		{
			Meat,
			Vegetables,
			Liquid,
			Spices
		}

		public Ingredient() { }

		public Ingredient(int id,IngredientType engridientType, string name, int fatPct, int carbPct, int protPct, int calories)
		{
			Id = id;
			Name = name;
			FatPct = fatPct;
			CarbPct = carbPct;
			ProtPct = protPct;
			Calories = calories;
		}
		public int Id { get; set; }

		public string Name
		{
			get; set;
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
			get; set;
		}
	}
}
