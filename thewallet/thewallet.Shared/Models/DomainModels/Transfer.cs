namespace thewallet.Shared.Models.DomainModels;

public class Transfer
{
    public int Id { get; set; }
    public int FromAccountId { get; set; }
    public int ToAccountId { get; set; }
    public int AssetId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransferTimestamp { get; set; }
}
