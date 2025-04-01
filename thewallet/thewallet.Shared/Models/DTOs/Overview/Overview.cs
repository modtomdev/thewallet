using System.Net.Http.Json;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Models.DTOs.Overview;

public class Overview
{
    public IEnumerable<GraphDTO> OverviewGraph { get; set; } = [];
    public IEnumerable<AccountDTO> Accounts { get; set; } = [];
}


