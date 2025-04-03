using ApexCharts;
using Microsoft.AspNetCore.Components;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Pages.Overview;

public partial class Index
{
    private string Factor => FormFactor.GetFormFactor();
    private string Platform => FormFactor.GetPlatform();

    private IEnumerable<OverviewDTO> _accounts = [];
    private IEnumerable<GraphDTO> _graph = [];

    private bool _graphIsLoading = true;
    private decimal _totalValue;

    protected override async Task OnInitializedAsync()
    {
        _graph = await OverviewService.GetGraphDTOsAsync();
        foreach (var item in _graph)
        {
            item.TotalValueEur = Math.Round(item.TotalValueEur);
        }
        _graphIsLoading = false;

        _accounts = await OverviewService.GetAccountDTOsAsync();
        _totalValue = Math.Round(_accounts.Sum(x => x.TotalValueEur), 2);
    }
    private void OnAccountClick(OverviewDTO overview)
    {
        NavigationManager.NavigateTo($"accounts/{overview.AccountId}");
    }
}