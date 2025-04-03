using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Web.Endpoints.Aggregate;

public static class AccountAggregateEndpoints
{
    public static IEndpointRouteBuilder MapAccountAggregateEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/accountsoverview");

        endpoints.MapGet("/user/{id:int}", GetAccountsAsync);
        endpoints.MapGet("/graph/user/{id:int}", GetGraphsAsync);

        return route;
    }

    private static async Task<Ok<IEnumerable<AccountDTO>>> GetAccountsAsync(int id, IAccountAggregateService data)
    {
        var accountDto = await data.GetOverviewAsync(1);
        return TypedResults.Ok(accountDto);
    }
    private static async Task<Ok<Dictionary<int, List<GraphSnapshotDTO>>>> GetGraphsAsync(int id, IAccountAggregateService data)
    {
        var graphDto = await data.GetGraphsByUserIdAsync(1); //fixed on user 1
        return TypedResults.Ok(graphDto);
    }
}
