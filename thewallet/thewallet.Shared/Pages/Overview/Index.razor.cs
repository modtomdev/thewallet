using thewallet.Shared.Models.DTOs.Overview;

namespace thewallet.Shared.Pages.Overview;

public partial class Index
{
    private string Factor => FormFactor.GetFormFactor();
    private string Platform => FormFactor.GetPlatform();

    private IEnumerable<AccountDTO> _accounts = [];
    private IEnumerable<GraphDTO> _graph = [];

    private List<GraphDTO> Data { get; set; } = [];

    private decimal _totalValue;

    protected override async Task OnInitializedAsync()
    {
        _accounts = await OverviewService.GetAccountDTOsAsync();
        _graph = await OverviewService.GetGraphDTOsAsync();
        _totalValue = Math.Round(_accounts.Sum(x => x.TotalValueEur), 2);

        Data.AddRange(_graph);
    }
}