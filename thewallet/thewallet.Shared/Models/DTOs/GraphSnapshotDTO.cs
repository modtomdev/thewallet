namespace thewallet.Shared.Models.DTOs;

public class GraphSnapshotDTO
{
    public int AccountId { get; set; }
    public decimal TotalValueEur { get; set; }
    public DateTime SnapshotTimestamp { get; set; }
}

