namespace thewallet.Shared.Models.DTOs;

public class AccountDTO
{
    public int AccountId { get; set; }
    public string AccountName { get; set; } = default!;
    public decimal TotalValueEur { get; set; }
    public IEnumerable<GraphSnapshotDTO> Graph { get; set; } = [];
}
