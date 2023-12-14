using _4UgersProjekt.Pages.Recipes;
using _4UgersProjekt.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _4UgersProjekt.Models
{
    public class Customer : IHaveIdAndName
    {
        public Customer()
        {
            MealPlans[CreateCustomerModel.Weekday.Monday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Tuesday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Wedensday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Thursday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Friday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Saturday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Sunday] = new CreateCustomerModel.DailyMealPlan();
        }

        public Customer(int id, string name, string email, bool kundeKlub)
        {
            Id = id;
            Name = name;
            Email = email;
            KundeKlub = kundeKlub;

            MealPlans[CreateCustomerModel.Weekday.Monday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Tuesday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Wedensday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Thursday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Friday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Saturday] = new CreateCustomerModel.DailyMealPlan();
            MealPlans[CreateCustomerModel.Weekday.Sunday] = new CreateCustomerModel.DailyMealPlan();
        }

        public Dictionary<CreateCustomerModel.Weekday, CreateCustomerModel.DailyMealPlan> MealPlans { get; set; } = new Dictionary<CreateCustomerModel.Weekday, CreateCustomerModel.DailyMealPlan>();

        [Display(Name = "Customer ID")]
        [Required(ErrorMessage = "Customer ID is needed")]
        [Range(typeof(int), "0", "10000", ErrorMessage = "ID skal være mellem {1} og {2}")]
        public int Id { get; set; }

        [Display(Name = "Customer name")]
        [Required(ErrorMessage = "Customer name is needed")]
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Kundeklub")]
        public bool KundeKlub { get; set; }

        public List<Recipe> Favorites { get; set; } = new List<Recipe>();

        
    }
}