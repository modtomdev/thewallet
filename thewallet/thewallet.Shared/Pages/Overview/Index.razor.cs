using Microsoft.AspNetCore.Components;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Pages.Overview;

public partial class Index
{
    private string Factor => FormFactor.GetFormFactor();
    private string Platform => FormFactor.GetPlatform();

    private IEnumerable<AccountDTO> _accounts = [];
    private IEnumerable<GraphSnapshotDTO> _graph = [];

    private bool _graphIsLoading = true;
    private decimal _totalValue;

    protected override async Task OnInitializedAsync()
    {
        _graph = await OverviewService.GetOverviewGraphAsync(1);
        foreach (var item in _graph)
        {
            item.TotalValueEur = Math.Round(item.TotalValueEur);
        }
        _graphIsLoading = false;

        _accounts = await OverviewService.GetOverviewAsync(1);
        _totalValue = Math.Round(_accounts.Sum(x => x.TotalValueEur), 2);
    }
    private void OnAccountClick(AccountDTO overview)
    {
        NavigationManager.NavigateTo($"accounts/{overview.Id}");
    }
}