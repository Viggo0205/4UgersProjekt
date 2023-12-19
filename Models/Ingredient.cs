using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// Victor
namespace _4UgersProjekt.Models
{
	public class Ingredient : IHaveIdAndName
	{
		[BindProperty]
		public IngredientType IngredientT { get; set; }
		public enum IngredientType
		{
			Meat,
			Vegetables,
			Liquid,
			Spices
		}

		public Ingredient() { }

		public Ingredient(int id,IngredientType IngridientType, string name, int fatPct, int carbPct, int protPct, int calories)
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
			get; set;
		}
		public int CarbPct
		{
			get; set;
		}
		public int ProtPct
		{
			get; set;
		}

		/*public IngredientType IngredientT
		{
			get; set;
		}*/

		public int Calories
		{
			get; set;
		}
	}
}
