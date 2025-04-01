using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Services;

public interface IGraphSnapshotService
{
    Task<IEnumerable<GraphSnapshot>> GetAllAsync();
    Task<GraphSnapshot?> GetByIdAsync(int graphSnapshotId);
    Task<int> CreateAsync(GraphSnapshot graphSnapshot);
    Task<bool> UpdateAsync(GraphSnapshot graphSnapshot);
    Task<bool> DeleteAsync(int graphSnapshotId);
    Task<int> GetCountAsync();
    Task<IEnumerable<GraphSnapshot>> GetByAccountIdAsync(int graphSnapshotId);
}
