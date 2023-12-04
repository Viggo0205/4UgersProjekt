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

    public class Recipes : IHaveIdAndName
    {
        public Recipes()
        {
        }

        public Recipes(int id, string name, List<RecipeComponent> ingredients)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
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
						totalCalories += Ingredients[i].Ingridient.Calories;
					}
                    return totalCalories;
				}
                else

                return totalCalories;
            }
        }
    }
}
