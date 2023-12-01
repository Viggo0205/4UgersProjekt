using _4UgersProjekt.Models;

namespace _4UgersProjekt.Services
{
	public interface ICustomerService : IService<Customer>
	{
		string GetEmail();
		bool GetKundeServiceStatus();
	}
}
