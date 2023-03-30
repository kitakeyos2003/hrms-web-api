using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IRepository<T, E>
    {
        List<T> GetAll();
        T Get(int id);
        T Add(E e);
        void Update(T t);
        void Delete(int id);
    }
}
