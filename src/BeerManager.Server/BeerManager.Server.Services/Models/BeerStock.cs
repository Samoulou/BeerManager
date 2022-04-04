namespace BeerManager.Server.Services.Models;
public class BeerStock
{
    public Guid BeerStockId { get; set; }
    public int Quantity { get; set; }
    public DateTimeOffset BrewingDate { get; set; }
}

