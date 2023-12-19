using _4UgersProjekt.Models;
//Victor
namespace _4UgersProjekt.Services
{
    public interface ICustomerService : IService<Customer>
    {
        string GetEmail();
        bool GetKundeServiceStatus();
        void SetCurrentCustomer(Customer customer);
    }
}