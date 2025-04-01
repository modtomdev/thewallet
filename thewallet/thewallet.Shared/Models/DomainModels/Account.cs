namespace thewallet.Shared.Models.DomainModels;

public class Account
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public required User Owner { get; set; }
    public IEnumerable<AssetHolding> AssetHoldings { get; set; } = [];
    public IEnumerable<AccountTransaction> AccountTransactions { get; set; } = [];
    public IEnumerable<Transfer> FromTransfers { get; set; } = [];
    public IEnumerable<Transfer> ToTransfers { get; set; } = [];
    public IEnumerable<GraphSnapshot> AccountGraph { get; set; } = [];

}
