using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Web.Endpoints.Aggregate;

public static class AccountAggregateEndpoints
{
    public static IEndpointRouteBuilder MapAccountAggregateEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/accountsoverview");

        endpoints.MapGet("/user1", GetAccountsAsync);
        endpoints.MapGet("/graph/user1", GetGraphAsync);

        return route;
    }

    private static async Task<Ok<IEnumerable<AccountDTO>>> GetAccountsAsync(IAccountAggregateService data)
    {
        var accountDto = await data.GetOverviewAsync();
        return TypedResults.Ok(accountDto);
    }
    private static async Task<Ok<IEnumerable<GraphSnapshotDTO>>> GetGraphAsync(IAccountAggregateService data)
    {
        var graphDto = await data.GetGraphByUserIdAsync(1);
        return TypedResults.Ok(graphDto);
    }
}
