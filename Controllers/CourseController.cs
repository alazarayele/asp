using asp.Data;
using asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly AspContext _aspContext;
    public CourseController(AspContext aspContext)
    {
        _aspContext=aspContext;
    }

    [HttpGet]
    public List<Course> GetCourses()
    {
        return _aspContext.Courses.ToList();
    }

    [HttpPost]
    public string AddCourse(Course course)
    {
        _aspContext.Courses.Add(course);
        _aspContext.SaveChanges();
        return "OK";
    }
}