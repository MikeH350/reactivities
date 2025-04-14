using Domain;

namespace Application.Activities.Dtos;

public class ActivityDto
{
    public string Id {get; set;} = Guid.NewGuid().ToString();
    public required string Title {get; set;}

    public DateTime Date  {get;set;} //Will give a default date. 
    public required string Description {get;set;}
    public required string Category {get;set;}
}
