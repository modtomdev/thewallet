using System.Net.Http.Json;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Services.Aggregate;

public class AccountAggregateService : IAccountAggregateService
{
    private readonly HttpClient _httpClient;

    public AccountAggregateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<AccountDTO>> GetOverviewAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<AccountDTO>>($"thewalletapi/accountsoverview/user/{id}") ?? [];
    }
    
    public async Task<Dictionary<int, List<GraphSnapshotDTO>>> GetGraphsByUserIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Dictionary<int, List<GraphSnapshotDTO>>>($"thewalletapi/accountsoverview/graph/user/{id}") ?? [];
    }
}
