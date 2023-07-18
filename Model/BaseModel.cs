namespace asp.Model;


public class BaseModel
{
    public int Id { get; protected set; }
    public DateTime CretaedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
    public BaseModel()
    {}
}