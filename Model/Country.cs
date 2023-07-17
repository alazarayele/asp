namespace asp.Model;

public class Country
{

    public int CountryId {get;set;}
    public string Name {get;set;}
    public int Population {get;set;}
    public int continent {get;set;}
    public CapitalCity CapitalCity{get;set;}  //Refernce Navigation

}