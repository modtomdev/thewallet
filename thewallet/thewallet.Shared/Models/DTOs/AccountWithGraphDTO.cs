namespace thewallet.Shared.Models.DTOs;

public class AccountWithGraphDTO
{
    public AccountDTO Account { get; set; } = default!;
    public List<GraphSnapshotDTO> Graphs { get; set; } = [];
}
