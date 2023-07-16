using asp.Data;
using asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentController : ControllerBase
{
    private readonly AspContext _aspContext;
    public StudentController(AspContext aspContext)
    {
        _aspContext=aspContext;

    }


    // [HttpGet]
    // public List<Student> GetStudents(){
    //     return _aspContext.Students.ToList();
    // }

     [HttpGet]
    public List<Student> GetStudents(){
        return _aspContext.Students.Include(x=>x.Courses).ToList();
    }


    [HttpPost]
    public string AddStudent(Student student)
    {
        _aspContext.Students.Add(student);
        _aspContext.SaveChanges();
        return "OK";
    }

   [HttpDelete("{id}")]
   
   public string DeleteStudent(int id)
   {
    Student student=GetStudent(id);
   
    _aspContext.Students.Remove(student);
    _aspContext.SaveChanges();
    return "Deleted";

   }

    [HttpGet("{id}")]
    public Student GetStudent(int id)
    {
        return _aspContext.Students.SingleOrDefault(stu=>stu.Id==id);
    }
    
}