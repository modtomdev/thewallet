using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Pages.Accounts;

public partial class Index
{
    //pulsante edit per aggiungere o rimuovere account, rinominare account
    private IEnumerable<AccountDTO> _accounts = [];
    private IEnumerable<GraphSnapshotDTO> _graphs = [];

    private List<AccountWithGraphDTO> _accountsWithGraphs = [];
    private bool _graphsAreLoading = true;

    protected override async Task OnInitializedAsync()
    {
        _accounts = await FrontService.GetOverviewAsync(1);
        _graphs = await FrontService.GetGraphsByUserIdAsync(1);

        _accountsWithGraphs = _accounts
        .GroupBy(x => x.Id)
        .Select(g => new AccountWithGraphDTO
        {
            Account = new AccountDTO
            {
                Id = g.Key,
                AccountName = g.First().AccountName,
                TotalValueEur = Math.Round(g.Sum(x => x.TotalValueEur), 2)
            },
            Graphs = _graphs
                .Where(graph => graph.AccountId == g.Key)
                .ToList()
        })
        .ToList();


        _graphsAreLoading = false;
    }
    private void OnAccountClick(AccountDTO account)
    {
        NavigationManager.NavigateTo($"accounts/{account.Id}");
    }
}
