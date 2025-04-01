using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs.Overview;

namespace thewallet.Web.Services;

public interface IOverviewService
{
    Task<IEnumerable<AccountDTO>> GetAccountDTOsAsync();
    Task<IEnumerable<GraphDTO>> GetGraphDTOsAsync();
}