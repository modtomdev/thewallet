using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Interfaces.Aggregates;

public interface IAccountAggregateService
{
    Task<IEnumerable<AccountDTO>> GetOverviewAsync(int id);
    Task<Dictionary<int, List<GraphSnapshotDTO>>> GetGraphsByUserIdAsync(int id);
}
