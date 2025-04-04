using Microsoft.AspNetCore.Components;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Shared.Pages.Accounts;

public partial class Details
{
    //grafico e info base come index
    //lista assets con quantità nome e valore totale in €
    //lista di transazioni legate all'account
    //
    //edit permette di aggiungere rimuovere assets all'account (es.aggiungo una nuova cripto)
    [Parameter]
    public int Id { get; set; }

    private AccountDTO _account = new();
    private IEnumerable<GraphSnapshot> _graph = [];

    private bool _graphsAreLoading = true;

    protected override async Task OnInitializedAsync()
    {
        _account = await FrontService.GetSingleOverviewAsync(1, Id) ?? new(); //review Id passing
        _graph = await GraphSnapshotService.GetByAccountIdAsync(1, Id);

        _graphsAreLoading = false;
    }
}
