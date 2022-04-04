using System.Runtime.Serialization;

namespace BeerManager.Core.Data.Models;

public class Contact
{
    public Guid ContactId { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public int PostalCode { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset ModificationDate { get; set; }

    [IgnoreDataMember]
    public List<Customer> Customers { get; set; }
}
