using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Interfaces.Aggregates;

public interface IAccountAggregateService
{
    Task<IEnumerable<GraphSnapshotDTO>> GetGraphsByUserIdAsync(int id);
}
