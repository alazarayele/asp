namespace asp.Infrastructure.Applied;
using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class StudentRepository : BaseRepository<Student>,IStudentRepository
{
    private readonly AspContext _aspContext;
    public StudentRepository(AspContext aspContext):base(aspContext)
    {
        _aspContext=aspContext;
    }
    public override IReadOnlyList<Student> GetAll()
    {
        return _aspContext.Students.Include(x=>x.Courses).ToList();
    }
}