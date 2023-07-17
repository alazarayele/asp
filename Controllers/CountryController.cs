using asp.Data;
using asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryControllers : ControllerBase
{
    private readonly AspContext _aspContext;

    public CountryControllers(AspContext aspContext)
    {
            _aspContext=aspContext;
    }


    [HttpGet]
    public List<Country> GetCountries()
    {
        return _aspContext.Countries.ToList();
    }

    [HttpPost]
    public string AddCountries(Country country)
    {
        _aspContext.Countries.Add(country);
        _aspContext.SaveChanges();
        return "ok";
    }

    [HttpGet("{id}")]

    public Country GetCountry(int id)
    {
        return _aspContext.Countries.SingleOrDefault(country=>country.CountryId==id);
    }

    [HttpDelete("{id}")]
    public string DeleteCountry(int id)
    {
        Country country=GetCountry(id);
        _aspContext.Countries.Remove(country);
        _aspContext.SaveChanges();
        return "Deleted";

    }
}