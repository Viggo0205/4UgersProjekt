using _4UgersProjekt.Models;
using _4UgersProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _4UgersProjekt.Pages.Recipes
{
    public class GetAllCustomersModel : PageModel
    {
        public List<Models.Customer>? Customer { get; private set; }

        [BindProperty]
        public string SearchString { get; set; }



        private ICustomerService _customerService;

        public GetAllCustomersModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult OnPostNameSearch()
        {
            Customer = _customerService.NameSearch(SearchString).ToList();
            return Page();
        }


        public void OnGet()
        {
          Customer = _customerService.Get();
        }
    }
}
