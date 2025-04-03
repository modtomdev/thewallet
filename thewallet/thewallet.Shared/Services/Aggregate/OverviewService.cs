using System.Net.Http.Json;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Services.Aggregate;

public class OverviewService : IOverviewService
{
    private readonly HttpClient _httpClient;

    public OverviewService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<AccountDTO>> GetAccountDTOsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<AccountDTO>>($"thewalletapi/overview/user1") ?? [];
    }

    public async Task<IEnumerable<GraphSnapshotDTO>> GetGraphDTOsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<GraphSnapshotDTO>>($"thewalletapi/overview/graph/user1") ?? [];
    }

    public Task<IEnumerable<AccountDTO>> GetOverviewAsync()
    {
        throw new NotImplementedException();
    }
}
