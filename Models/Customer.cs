using System.ComponentModel.DataAnnotations;

namespace _4UgersProjekt.Models
{
	public class Customer
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


	}
}
