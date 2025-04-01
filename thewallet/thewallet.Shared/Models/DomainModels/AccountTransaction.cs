namespace thewallet.Shared.Models.DomainModels;

public class AccountTransaction
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CategoryId { get; set; }
    public int AssetId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = default!;
    public DateTime TransactionTimestamp { get; set; }
    public required Account AssociatedAccount { get; set; }
    public required Category AssociatedCategory { get; set; }
    public required AssetHolding AssociatedAssetHolding { get; set; }
}
