using _4UgersProjekt.Models;
using _4UgersProjekt.Pages.Recipes;

namespace _4UgersProjekt.Services
{
    public class CustomerService : DataRepository<Customer>, ICustomerService
    {

        private readonly IRecipeService _recipeService;

        public CustomerService(IWebHostEnvironment webHostEnvironment, IRecipeService recipeService) : base(new JSonFileCustomerService(webHostEnvironment))
        {
            _recipeService = recipeService;
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

        public void SetCurrentCustomer(Customer customer)
        {
            _customer = customer;
        }

        public override void Update(Customer item)
        {
            if (item != null)
            {
                Customer existingCustomer = Get(item.Id);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = item.Name;
                    existingCustomer.Email = item.Email;
                    existingCustomer.KundeKlub = item.KundeKlub;

                    // Update favorite recipes
                    existingCustomer.Favorites.Clear();
                    foreach (var recipe in item.Favorites)
                    {
                        existingCustomer.Favorites.Add(recipe);
                    }

                    // Update meal plans
                    for (int day = 0; day < 7; day++)
                    {
                        existingCustomer.MealPlans[(CreateCustomerModel.Weekday)day].Morning =
                            _recipeService.Get(item.MealPlans[(CreateCustomerModel.Weekday)day].Morning?.Id ?? 0);

                        existingCustomer.MealPlans[(CreateCustomerModel.Weekday)day].Noon =
                            _recipeService.Get(item.MealPlans[(CreateCustomerModel.Weekday)day].Noon?.Id ?? 0);

                        existingCustomer.MealPlans[(CreateCustomerModel.Weekday)day].Evening =
                            _recipeService.Get(item.MealPlans[(CreateCustomerModel.Weekday)day].Evening?.Id ?? 0);
                    }

                    _jsonFile.SaveJson(_data);
                }
            }
        }

        public void AddFavoriteRecipe(int customerId, Recipe recipe)
        {
            var customer = Get(customerId);
            if (customer != null)
            {
                customer.Favorites.Add(recipe);
                Update(customer);
            }
        }

        public void RemoveFavoriteRecipe(int customerId, Recipe recipe)
        {
            var customer = Get(customerId);
            if (customer != null)
            {
                customer.Favorites.Remove(recipe);
                Update(customer);
            }
        }
    }

}
