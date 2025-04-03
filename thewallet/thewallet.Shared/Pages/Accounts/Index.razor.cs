using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Pages.Accounts;

public partial class Index
{
    private IEnumerable<OverviewDTO> _accounts = [];
    protected override async Task OnInitializedAsync()
    {
        //_accounts = await AccountService.GetAllAsync();
    }
    private void OnAccountClick(OverviewDTO account)
    {
        NavigationManager.NavigateTo($"accounts/{account.AccountId}");
    }
}
