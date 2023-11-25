﻿
namespace _4UgersProjekt.Services
{
    public interface IHaveIdAndName
    {
        int Id { get; }
        int Name { get; set; }
    }

    public abstract class DataRepository<T> : IService<T> where T : class, IHaveIdAndName
    {
        protected List<T> _data;
        protected JsonFileService<T> _jsonFile;


        public DataRepository(JsonFileService<T> jsonFile)
        {
            _data = new List<T>();
            _jsonFile = jsonFile;
        }


        public List<T> Get()
        {
            return _data;
        }
        public void Add(T t)
        {
            _data.Add(t);
            _jsonFile.SaveJson(_data);
        }
        public IEnumerable<T> NameSearch(string str)
        {
            List<T> nameSearch = new List<T>();
            foreach (T t in _data)
            {
                if (string.IsNullOrEmpty(str) || t.Name.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(t);
                }
            }

            return nameSearch;
        }


        public abstract void Update(T item);


        public T Get(int id)
        {
            foreach (T item in _data)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public T Delete(int? itemId)
        {
            T itemToBeDeleted = null;
            foreach (T item in _data)
            {
                if (item.Id == itemId)
                {
                    _data.Remove(item);
                    return item;
                }
            }
            if (itemToBeDeleted != null)
            {
                _data.Remove(itemToBeDeleted);
                _jsonFile.SaveJson(_data);
            }

            return itemToBeDeleted;
        }
    }
}
