namespace asp.Model;


public class Course : BaseModel
{
    
    public string Name{get;set;}

    public string Description{get;set;}

    public int CreditHour{get;set;}
    
    public Student Student{get;set;}
    public int? StudentId{get;set;}
}