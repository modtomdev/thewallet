using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Pages.Accounts;

public partial class Index
{
    private IEnumerable<AccountDTO> _accounts = [];
    private Dictionary<int, List<GraphSnapshotDTO>> _graphs = [];

    private bool _graphsAreLoading = true;
    private List<GraphSnapshotDTO> _graph = [];
    protected override async Task OnInitializedAsync()
    {
        _accounts = await AccountAggregateService.GetOverviewAsync(1);
        _graphs = await AccountAggregateService.GetGraphsByUserIdAsync(1);
        //
        //
        //

        _graphsAreLoading = false;
    }
    private void OnAccountClick(AccountDTO account)
    {
        NavigationManager.NavigateTo($"accounts/{account.AccountId}");
    }
}
