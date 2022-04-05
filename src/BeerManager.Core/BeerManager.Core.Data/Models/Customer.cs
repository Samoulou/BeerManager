using System.Runtime.Serialization;

namespace BeerManager.Core.Data.Models;

public class Customer
{
    public Guid CustomerId { get; set; }
    public Guid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset ModificationDate { get; set; }


    [IgnoreDataMember]
    public Contact Contact { get; set; }
    [IgnoreDataMember]
    public List<Order> Orders { get; set; }
}