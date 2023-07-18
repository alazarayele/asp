using asp.Data;
using asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly AspContext _aspContext;

    public EmployeeController(AspContext aspContext)
    {
            _aspContext=aspContext;
    }


    [HttpGet]
    public List<Employee> GetEmployees()
    {
        return _aspContext.Employees.ToList();
    }

    [HttpPost]
    public string AddEmployess(Employee employee)
    {
        _aspContext.Employees.Add(employee);
        _aspContext.SaveChanges();
        return "ok";
    }

    [HttpGet("{id}")]

    public Employee GetEmployee(int id)
    {
        return _aspContext.Employees.SingleOrDefault(employee=>employee.Id==id);
    }

    [HttpDelete("{id}")]
    public string DeletEmployee(int id)
    {
        Employee employee=GetEmployee(id);
        _aspContext.Employees.Remove(employee);
        _aspContext.SaveChanges();
        return "Deleted";

    }
}