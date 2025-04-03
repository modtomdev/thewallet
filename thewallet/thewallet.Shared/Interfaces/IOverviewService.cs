using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Web.Services;

public interface IOverviewService
{
    Task<IEnumerable<OverviewDTO>> GetAccountDTOsAsync();
    Task<IEnumerable<GraphDTO>> GetGraphDTOsAsync();
}