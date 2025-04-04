namespace thewallet.Shared.Models.DomainModels;

public class GraphSnapshot
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public DateTime GraphTimestamp { get; set; }
    public decimal AccountValueEur { get; set; }
}
