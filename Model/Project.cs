namespace asp.Model;



public class Project : BaseModel
{
 
 public string Name{get;set;}

    public string Station{get;set;}
    public ICollection<EmployeeProject>EmployeeProjects{get;set;}
}