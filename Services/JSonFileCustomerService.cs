using _4UgersProjekt.Models;

namespace _4UgersProjekt.Services
{
	public class JSonFileCustomerService : JsonFileService<Customer>
	{

	
			public JSonFileCustomerService(IWebHostEnvironment webHostEnvironment)
				: base(webHostEnvironment)
			{
			}

			protected override string JsonFileName
			{
				get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Customer.json"); }
			}
		
	}
}
