using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Web.Endpoints.Aggregate;

public static class AccountAggregateEndpoints
{
    public static IEndpointRouteBuilder MapAccountAggregateEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/accountsoverview");

        endpoints.MapGet("/user/{id:int}/graph", GetGraphsAsync);

        return route;
    }

    private static async Task<Ok<IEnumerable<GraphSnapshotDTO>>> GetGraphsAsync(int id, IAccountAggregateService data)
    {
        var graphDto = await data.GetGraphsByUserIdAsync(id);
        return TypedResults.Ok(graphDto);
    }
}
