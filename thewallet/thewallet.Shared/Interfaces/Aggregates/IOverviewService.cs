using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Interfaces.Aggregates;

public interface IOverviewService
{
    Task<IEnumerable<AccountDTO>> GetOverviewAsync(int id);
    Task<IEnumerable<GraphSnapshotDTO>> GetGraphDTOsAsync(int id);
}
