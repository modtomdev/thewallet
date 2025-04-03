using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Interfaces.Aggregates;

public interface IOverviewService
{
    Task<IEnumerable<AccountDTO>> GetOverviewAsync();
    Task<IEnumerable<GraphSnapshotDTO>> GetGraphDTOsAsync();
}
