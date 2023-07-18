namespace asp.Infrastructure.Applied;

using System.Collections.Generic;
using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;


public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel

{
    private readonly AspContext _aspContext;

    public BaseRepository(AspContext aspContext)
    {
        _aspContext = aspContext;
    }
    public string Add(T t)
    {
        _aspContext.Set<T>().Add(t);
        _aspContext.SaveChanges();
        return "Succesfully Added";
    }

    public string Delete(T t)
    {
        _aspContext.Set<T>().Remove(t);
        _aspContext.SaveChanges();
        return "Successfully Deleted";
    }

    public virtual IReadOnlyList<T> GetAll()
    {
       return _aspContext.Set<T>().ToList();

    }

    public T GetById(int id)
    {
        return _aspContext.Set<T>().SingleOrDefault(x=>x.Id==id);
    }

    public string Update(T t)
    {
      return "ok";
    }
}