using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Services.CRUD;

public class GraphSnapshotService : IGraphSnapshotService
{
    public Task<int> CreateAsync(GraphSnapshot graphSnapshot)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int graphSnapshotId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GraphSnapshot>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GraphSnapshot>> GetByAccountIdAsync(int graphSnapshotId)
    {
        throw new NotImplementedException();
    }

    public Task<GraphSnapshot?> GetByIdAsync(int graphSnapshotId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(GraphSnapshot graphSnapshot)
    {
        throw new NotImplementedException();
    }
}
