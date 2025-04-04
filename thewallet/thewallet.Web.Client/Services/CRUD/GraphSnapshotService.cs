using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;
using System.Net.Http.Json;

namespace thewallet.Shared.Services.CRUD;

public class GraphSnapshotService : IGraphSnapshotService
{
    private readonly HttpClient _httpClient;

    public GraphSnapshotService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

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

    public async Task<IEnumerable<GraphSnapshot>> GetByAccountIdAsync(int userId, int accountId)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<GraphSnapshot>>($"/api/accountsoverview/user/{userId}/{accountId}") ?? [];
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
