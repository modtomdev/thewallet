using System.Net.Http.Json;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Services.Aggregate;

public class OverviewService : IOverviewService
{
    private readonly HttpClient _httpClient;

    public OverviewService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("thewalletapi");
    }

    public async Task<IEnumerable<AccountDTO>> GetOverviewAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<AccountDTO>>($"overview/user/{id}") ?? [];
    }

    public async Task<IEnumerable<GraphSnapshotDTO>> GetOverviewGraphAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<GraphSnapshotDTO>>($"overview/user/{id}/graph") ?? [];
    }
}
