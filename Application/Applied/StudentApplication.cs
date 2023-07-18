namespace asp.Application.Applied;

using System.Collections.Generic;
using asp.Application.Interface;
using asp.Model;
using asp.Infrastructure.Interface;

public class StudentApplication : IStudent
{
    private readonly IStudentRepository _iStudentRepository;
    public StudentApplication(IStudentRepository studentRepository)
    {
        _iStudentRepository=studentRepository;
    }
    public string Add(Student student)
    {
        return _iStudentRepository.Add(student);
        
    }

    public string Delete(int id)
    {
        var student=GetById(id);
       return _iStudentRepository.Delete(student);
    }

    public IReadOnlyList<Student> GetAll()
    {
        return _iStudentRepository.GetAll();
    }

    public Student GetById(int id)
    {
       return _iStudentRepository.GetById(id);
    }

    public string Update(int id)
    {
        throw new NotImplementedException();
    }
}