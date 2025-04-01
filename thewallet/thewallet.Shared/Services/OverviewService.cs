using System.Net.Http.Json;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs.Overview;
using thewallet.Web.Services;

namespace thewallet.Shared.Services;

public class OverviewService : IOverviewService
{
    private readonly HttpClient _httpClient;

    public OverviewService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<AccountDTO>> GetAccountDTOsAsync()
    {
        return _httpClient.GetFromJsonAsync<IEnumerable<AccountDTO>>($"thewalletapi/overview/user1")!;
    }

    public Task<IEnumerable<GraphDTO>> GetGraphDTOsAsync()
    {
        return _httpClient.GetFromJsonAsync<IEnumerable<GraphDTO>>($"thewalletapi/overview/graph/user1")!;
    }
}
