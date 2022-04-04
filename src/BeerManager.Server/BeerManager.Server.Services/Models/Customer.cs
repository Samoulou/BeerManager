namespace BeerManager.Server.Services.Models;
public class Customer
{
    public Guid CustomerId { get; set; }
    public Guid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Contact Contact { get; set; }
}