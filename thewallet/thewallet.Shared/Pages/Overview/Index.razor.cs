using thewallet.Shared.Models.DTOs.Overview;

namespace thewallet.Shared.Pages.Overview;

public partial class Index
{
    private string Factor => FormFactor.GetFormFactor();
    private string Platform => FormFactor.GetPlatform();

    private IEnumerable<AccountDTO> _accounts = [];
    private IEnumerable<GraphDTO> _graph = [];

    private decimal _totalValue;

    //
    private List<string> _labels = [];
    private List<decimal> _data = [];


    protected override async Task OnInitializedAsync()
    {
        _accounts = await OverviewService.GetAccountDTOsAsync();
        _graph = await OverviewService.GetGraphDTOsAsync();
        _totalValue = Math.Round(_accounts.Sum(x => x.TotalValueEur), 2);
        foreach (var item in _graph)
        {
            _data.Add(item.TotalValueEur);
            _labels.Add(item.SnapshotTimestamp.ToString("yyyy/MM/dd"));
        }
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        
    }
}