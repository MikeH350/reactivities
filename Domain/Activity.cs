using System;

namespace Domain;

public class Activity //This is an Entity (Model), it represents a table in the database.
{
    //
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title {get;set;}
    public DateTime Date  {get;set;} //Will give a default date. 
    public required string Description {get;set;}
    public required string Category {get;set;}
    public bool IsCancelled {get; set;}       //Will default to false
    public required string City { get; set; }        
    public required string Venue  { get; set; }
    public double Latitude { get; set; }    //Will default to 0
    public double Longitude { get; set; }   //Will default to 0
    

}
