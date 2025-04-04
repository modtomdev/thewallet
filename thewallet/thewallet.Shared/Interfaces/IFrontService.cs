using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Interfaces;

public interface IFrontService
{
    Task<IEnumerable<AccountDTO>> GetOverviewAsync(int userId);
    Task<IEnumerable<GraphSnapshotDTO>> GetOverviewGraphAsync(int userId);
    Task<IEnumerable<GraphSnapshotDTO>> GetGraphsByUserIdAsync(int userId);
    Task<AccountDTO?> GetSingleOverviewAsync(int userId, int accountId);
}
