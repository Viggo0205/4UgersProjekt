using _4UgersProjekt.Models;

namespace _4UgersProjekt.Services
{
	public class CustomerService : DataRepository<Customer>,ICustomerService
	{
		

		public CustomerService(IWebHostEnvironment webHostEnvironment) : base(new JSonFileCustomerService(webHostEnvironment))
		{
		}

	

		public Customer _customer = new Customer();

		public string GetEmail()
		{
			return _customer.Email;
		}

		public bool GetKundeServiceStatus()
		{
			return _customer.KundeKlub;
		}

		public override void Update(Customer item)
		{
			if (item != null)
			{
				foreach (Customer i in _data)
				{
					if (i.Id == item.Id)
					{
						i.Name = item.Name;
					}
				}
				_jsonFile.SaveJson(_data);
			}
		}

	}
}
