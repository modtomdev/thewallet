using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs;
using thewallet.Web.Services;

namespace thewallet.Web.Endpoints;

public static class OverviewEndpoints
{
    public static IEndpointRouteBuilder MapOverviewEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/overview");

        endpoints.MapGet("/user1", GetAccountsAsync);
        endpoints.MapGet("/graph/user1", GetGraphAsync);

        return route;
    }

    private static async Task<Ok<IEnumerable<AccountDTO>>> GetAccountsAsync(IOverviewService data)
    {
        var accountDto = await data.GetAccountDTOsAsync();
        return TypedResults.Ok(accountDto);
    }
    private static async Task<Ok<IEnumerable<GraphSnapshotDTO>>> GetGraphAsync(IOverviewService data)
    {
        var graphDto = await data.GetGraphDTOsAsync();
        return TypedResults.Ok(graphDto);
    }
}
