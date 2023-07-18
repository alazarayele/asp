using Microsoft.AspNetCore.Mvc;
using asp.Data;
using asp.Model;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityCountroller : ControllerBase
{
    private readonly AspContext _aspContext;
    public CityCountroller(AspContext aspContext)
    {
        _aspContext=aspContext;
    }

    [HttpGet]
    public List<CapitalCity> GetCapitalCities()
    {
        return _aspContext.CapitalCities.ToList();
    }

    [HttpPost]
    public string AddCity(CapitalCity capitalCity)
    {
        _aspContext.CapitalCities.Add(capitalCity);
        _aspContext.SaveChanges();
        return "Successfully Added";

    }
    [HttpGet("{id}")]
    public CapitalCity GetCapitalCity(int id)
    {
        return _aspContext.CapitalCities.SingleOrDefault(city => city.Id==id);
    }

    [HttpDelete("{id}")]
    public string DeleteCity(int id)
    {
        CapitalCity capitalCity=GetCapitalCity(id);
        _aspContext.CapitalCities.Remove(capitalCity);
        _aspContext.SaveChanges();
        return "Successfully Deleted";
    }

    [HttpPut("{id}")]
     public string UpdateCity(CapitalCity capitalCity,int id)
     {
       CapitalCity capitalCity1=GetCapitalCity(id);
        if(capitalCity1 != null)
             {
                 capitalCity1.CountryName = capitalCity.CountryName;
                 capitalCity1.NumberOfPopulation = capitalCity.NumberOfPopulation;
                 capitalCity1.CountryId = capitalCity.CountryId;
                  _aspContext.SaveChanges();
                   return "Updated";
          }
          else
          return "notUpdate";
       
       
    }
}