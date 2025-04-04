using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Interfaces;

public interface IFrontService
{
    Task<IEnumerable<AccountDTO>> GetOverviewAsync(int id);
    Task<IEnumerable<GraphSnapshotDTO>> GetOverviewGraphAsync(int id);
    Task<IEnumerable<GraphSnapshotDTO>> GetGraphsByUserIdAsync(int id);
}
