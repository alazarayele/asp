namespace asp.Application.Interface;
using asp.Model;
public interface IStudent
{
    IReadOnlyList<Student> GetAll();

    Student GetById(int id);

    string Add(Student student);

    string Delete(int id);

    string Update(int id); 
}