// Victor
namespace _4UgersProjekt.Services
{
    public interface IService<T>
    {
        List<T> Get();
        IEnumerable<T> NameSearch(string str);
        void Add(T t);
        void Update(T t);
        T Get(int id);
        T Delete(int? id);
    }
}
