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

    public async Task<IEnumerable<AccountDTO>> GetOverviewAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<AccountDTO>>($"thewalletapi/overview/user/{id}") ?? [];
    }

    public async Task<IEnumerable<GraphSnapshotDTO>> GetGraphDTOsAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<GraphSnapshotDTO>>($"thewalletapi/overview/graph/user/{id}") ?? [];
    }
}
