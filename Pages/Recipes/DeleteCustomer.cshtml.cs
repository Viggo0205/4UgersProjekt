using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//Jonas
namespace _4UgersProjekt.Pages.Recipes
{
    public class DeleteCustomerModel : PageModel
    {
        private ICustomerService _repo;

        public DeleteCustomerModel(ICustomerService repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Models.Customer Customer { get; set; }


        public IActionResult OnGet(int id)
        {
            Models.Customer? customer = _repo.Get(id);

            if (customer != null)
                Customer = customer;
            else
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Customer? deletedCustomer = _repo.Delete(Customer.Id);
            if (deletedCustomer == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return RedirectToPage("GetAllCustomers");
        }
    }
}
