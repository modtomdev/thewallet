using System.Net.Http.Json;
using thewallet.Shared.Interfaces;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Services;

public class FrontService : IFrontService
{
    private readonly HttpClient _httpClient;

    public FrontService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<AccountDTO>> GetOverviewAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<AccountDTO>>($"/api/overview/user/{id}") ?? [];
    }

    public async Task<IEnumerable<GraphSnapshotDTO>> GetOverviewGraphAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<GraphSnapshotDTO>>($"/api/overview/user/{id}/graph") ?? [];
    }
    public async Task<IEnumerable<GraphSnapshotDTO>> GetGraphsByUserIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<GraphSnapshotDTO>>($"/api/accountsoverview/user/{id}") ?? [];

    }
    public async Task<AccountDTO?> GetSingleOverviewAsync(int userId, int accountId)
    {
        return await _httpClient.GetFromJsonAsync<AccountDTO>($"/api/accountdetails/user/{userId}/account/{accountId}");
    }
}
