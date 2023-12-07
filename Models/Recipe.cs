using _4UgersProjekt.Services;
using System.ComponentModel.DataAnnotations;

namespace _4UgersProjekt.Models
{
	public enum MealType
	{
		Breakfast, 
        Lunch,
        Dinner,
        Snack
	}
    public enum GoalType
    {
     Bulk,
     Cut,
     Maintance
    }
    public class Recipe : IHaveIdAndName
    {
        public Recipe()
        {
            Ingredients = new List<RecipeComponent>();
        }

        public Recipe(int id, string name)
        {
            Id = id;
            Name = name;
            Ingredients = new List<RecipeComponent>();
		}

        [Display(Name = "Recipe ID")]
        [Required(ErrorMessage = "Recipe ID is needed")]
        [Range(typeof(int), "0", "10000", ErrorMessage = "ID skal være mellem {1} og {2}")]
        public int Id { get; set; }

        [Display(Name = "Recipe name")]
        [Required(ErrorMessage = "Recipe name is needed")]
        public string Name { get; set; }

        [Display(Name = "Recipe engridients")]
        [Required(ErrorMessage = "Recipe engridients is needed")]
        public List<RecipeComponent> Ingredients { get; set; }

        public int TotalCalories
        {
            
            get 
            {
				int totalCalories = 0;
                if(Ingredients!=null && Ingredients.Count>0)
                {
					for (int i = 0; i < Ingredients.Count; i++)
					{
						totalCalories += Ingredients[i].Ingredient.Calories;
					}
                    return totalCalories;
				}
                else

                return totalCalories;
            }
        }
    }
}
