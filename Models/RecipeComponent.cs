﻿namespace _4UgersProjekt.Models
{
	public class RecipeComponent
	{
		public Ingridient Ingridient { get; set; }
		public int Amount { get; set; }

		public RecipeComponent() { }

		public RecipeComponent(Ingridient ingridient,int amount) 
		{ 
			Ingridient = ingridient;
			Amount = amount;
		}
	}
}
