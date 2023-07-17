namespace asp.Model;


public class CapitalCity
{
    public int Id{get;set;}
    public string CountryName{get;set;}
    public int NumberOfPopulation{get;set;}

    public int CountryId {get;set;} //Foriegn Key
    public Country Country{get;set;} //Refernce navigation
    

}