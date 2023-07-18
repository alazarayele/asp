using asp.Data;
using asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        return _aspContext.Courses.Include(x=>x.Student).ToList();
    }

    [HttpPost]
    public string AddCourse(Course course)
    {
        _aspContext.Courses.Add(course);
        _aspContext.SaveChanges();
        return "OK";
    }
      [HttpGet("{id}")]
    public Course GetCourses(int id)
    {
        return _aspContext.Courses.SingleOrDefault(cou=>cou.Id==id);
    }

    [HttpDelete("{id}")]
    public string DeleteCourse(int id)
    {
        Course course=GetCourses(id);
        _aspContext.Courses.Remove(course);
        _aspContext.SaveChanges();
        return "Deleted";
    }

     [HttpPut("{id}")]
    public string UpdateCourse(Course courses,int id)
    {
      Course course=GetCourses(id);
       if(course != null)
            {
                course.Name = courses.Name;
                course.Description = courses.Description;
                course.CreditHour = courses.CreditHour;

                 _aspContext.SaveChangesAsync();
                  return "Updated";
         }
         else
         return "notUpdate";
       
       
    }
}