namespace BeerManager.Core.Data.Models;
public class BeerStock
{
    public Guid BeerStockId { get; set; }
    public int Quantity { get; set; }
    public DateTimeOffset BrewingDate { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset ModificationDate { get; set; }
}

