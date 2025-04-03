using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Web.Endpoints;

public static class OverviewEndpoints
{
    public static IEndpointRouteBuilder MapOverviewEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/overview");

        endpoints.MapGet("/user/{id:int}", GetAccountsAsync);
        endpoints.MapGet("/graph/user/{id:int}", GetGraphAsync);

        return route;
    }

    private static async Task<Ok<IEnumerable<AccountDTO>>> GetAccountsAsync(int id, IOverviewService data)
    {
        var accountDto = await data.GetOverviewAsync(1); //fixed on user 1
        return TypedResults.Ok(accountDto);
    }
    private static async Task<Ok<IEnumerable<GraphSnapshotDTO>>> GetGraphAsync(int id, IOverviewService data)
    {
        var graphDto = await data.GetGraphDTOsAsync(1); //fixed on user 1
        return TypedResults.Ok(graphDto);
    }
}
