namespace BeerManager.Server.Services.Models;
public class Contact
{
    public Guid ContactId { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public int PostalCode { get; set; }
}
