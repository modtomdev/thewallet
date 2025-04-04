using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Web.Endpoints;

public static class OverviewEndpoints
{
    public static IEndpointRouteBuilder MapOverviewEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/overview");

        endpoints.MapGet("/user/{id:int}", GetOverviewAsync);
        endpoints.MapGet("/user/{id:int}/graph", GetGraphAsync);

        return route;
    }

    private static async Task<Ok<IEnumerable<AccountDTO>>> GetOverviewAsync(int id, IOverviewService data)
    {
        var accountDto = await data.GetOverviewAsync(id);
        return TypedResults.Ok(accountDto);
    }
    private static async Task<Ok<IEnumerable<GraphSnapshotDTO>>> GetGraphAsync(int id, IOverviewService data)
    {
        var graphDto = await data.GetOverviewGraphAsync(id);
        return TypedResults.Ok(graphDto);
    }
}
