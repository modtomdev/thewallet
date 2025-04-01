namespace thewallet.Shared.Models.DomainModels;

public class Asset
{
    public int Id { get; set; }
    public string Symbol { get; set; } = default!;
    public string Name { get; set; } = default!;
    public decimal CurrentValueEur { get; set; }
    public DateTime ValueTimestamp { get; set; }
    public IEnumerable<AssetHolding> AssetHoldings { get; set; } = [];
}
