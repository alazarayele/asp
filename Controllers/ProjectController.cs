using asp.Data;
using asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly AspContext _aspContext;

    public ProjectController(AspContext aspContext)
    {
            _aspContext=aspContext;
    }


    [HttpGet]
    public List<Project> GetCountries()
    {
        return _aspContext.Projects.ToList();
    }

    [HttpPost]
    public string AddProjects(Project project)
    {
        _aspContext.Projects.Add(project);
        _aspContext.SaveChanges();
        return "ok";
    }

    [HttpGet("{id}")]

    public Project GetProject(int id)
    {
        return _aspContext.Projects.SingleOrDefault(project=>project.Id==id);
    }

    [HttpDelete("{id}")]
    public string DeleteProject(int id)
    {
        Project project=GetProject(id);
        _aspContext.Projects.Remove(project);
        _aspContext.SaveChanges();
        return "Deleted";

    }
}