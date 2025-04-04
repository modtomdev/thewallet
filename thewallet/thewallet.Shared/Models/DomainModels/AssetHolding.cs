namespace thewallet.Shared.Models.DomainModels;

public class AssetHolding
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int AssetId { get; set; }
    public decimal Quantity { get; set; }
    public DateTime PurchaseTimestamp { get; set; }
}
