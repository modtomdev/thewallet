using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Interfaces.Aggregates;

public interface IAccountAggregateService
{
    Task<IEnumerable<AccountDTO>> GetOverviewAsync();
    Task<IEnumerable<GraphSnapshotDTO>> GetGraphByUserIdAsync(int accountId);
}
