namespace asp.Model;


public class Employee : BaseModel
{
   
    public string  FirstName{get;set;}
    public string LastName{get;set;}
    public long Salary{get;set;}

    public ICollection<EmployeeProject>EmployeeProjects{get;set;}
}