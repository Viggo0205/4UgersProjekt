using _4UgersProjekt.Services;
using System.ComponentModel.DataAnnotations;

namespace _4UgersProjekt.Models
{
	public class Customer : IHaveIdAndName
	{
		public Customer() { }

		public Customer(int id, string name, string email, bool kundeKlub) 
		{
			Id = id;
			Name = name;
			Email = email;
			KundeKlub = kundeKlub;

		}

		
		[Display(Name = "Customer ID")]
		[Required(ErrorMessage = "Customer ID is needed")]
		[Range(typeof(int), "0", "10000", ErrorMessage = "ID skal være mellem {1} og {2}")]
		public int Id { get; set; }

		[Display(Name = "Customer name")]
		[Required(ErrorMessage = "Customer name is needed")]
		public string Name { get; set; }
		public string Email { get; set; }
		public bool KundeKlub { get; set; }
		public List<Recipes> Favorites {get; set;}
		public void AddFavorite(Recipes recipe)
		{
			if (!Favorites.Contains(recipe))
			{
				Favorites.Add(recipe);
			}
			else
			{
				throw new InvalidOperationException("You already have this as a favorite recipe");
			}
		}
		public void RemoveFavorite(Recipes recipe)
		{
			if (Favorites.Contains(recipe))
			{	
				Favorites.Remove(recipe);
			}
			else
			{
				throw new InvalidOperationException("This recipe does not exist");
			}
		}

	}
}
