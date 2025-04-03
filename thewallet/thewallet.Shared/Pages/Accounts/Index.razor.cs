using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Pages.Accounts;

public partial class Index
{
    private IEnumerable<AccountDTO> _accounts = [];
    private IEnumerable<GraphSnapshotDTO> _graph = [];
    private IEnumerable<IEnumerable<GraphSnapshotDTO>> _graphs = [];

    private bool _graphsAreLoading = true;
    protected override async Task OnInitializedAsync()
    {
        _accounts = await AccountAggregateService.GetOverviewAsync();
        for (int i = 0; i < _accounts.Count(); i++)
        {
            _graph = await AccountAggregateService.GetGraphByUserIdAsync(1);
            _graphs = _graphs.Append(_graph);
        }

        foreach (var graph in _graphs)
        {
            foreach (var value in graph)
            {
                value.TotalValueEur = Math.Round(value.TotalValueEur);
            }
        }
        _graphsAreLoading = false;
    }
    private void OnAccountClick(AccountDTO account)
    {
        NavigationManager.NavigateTo($"accounts/{account.AccountId}");
    }
}
