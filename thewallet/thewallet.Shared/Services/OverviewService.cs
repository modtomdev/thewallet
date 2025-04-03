using System.Net.Http.Json;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs;
using thewallet.Web.Services;

namespace thewallet.Shared.Services;

public class OverviewService : IOverviewService
{
    private readonly HttpClient _httpClient;

    public OverviewService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<OverviewDTO>> GetAccountDTOsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<OverviewDTO>>($"thewalletapi/overview/user1") ?? [];
    }

    public async Task<IEnumerable<GraphDTO>> GetGraphDTOsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<GraphDTO>>($"thewalletapi/overview/graph/user1") ?? [];
    }
}
