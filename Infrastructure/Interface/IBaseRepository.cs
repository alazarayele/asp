using asp.Model;

namespace asp.Infrastructure.Interface;

public interface IBaseRepository<T> where T:BaseModel
{
    IReadOnlyList<T> GetAll();

    T GetById(int id);

    string Add(T t);

    string Delete(T t);

    string Update(T t);
}