using System.Runtime.Serialization;

namespace BeerManager.Core.Data.Models;

public class Order
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public int OrderNumber { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DeliveryMode DeliveryMode { get; set; }
    public DateTimeOffset DeliveryDate { get; set; }
    public BeerType BeerType { get; set; }
    public OrderStatus Status { get; set; }
    public string Remarks { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset ModificationDate { get; set; }

    [IgnoreDataMember]
    public Customer Customer { get; set; }

}
