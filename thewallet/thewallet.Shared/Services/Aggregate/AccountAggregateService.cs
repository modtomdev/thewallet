using System.Diagnostics;
using System.Net.Http.Json;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Services.Aggregate;

public class AccountAggregateService : IAccountAggregateService
{
    private readonly HttpClient _httpClient;

    public AccountAggregateService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("thewalletapi");
    }
    public async Task<IEnumerable<GraphSnapshotDTO>> GetGraphsByUserIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<GraphSnapshotDTO>>($"overview/user/{id}/graph") ?? [];
    }
}
