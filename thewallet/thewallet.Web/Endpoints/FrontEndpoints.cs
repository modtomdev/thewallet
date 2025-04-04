using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Web.Endpoints;

public static class FrontEndpoints
{
    public static IEndpointRouteBuilder MapFrontEndpoints(this IEndpointRouteBuilder route)
    {

        var overviewEndpoints = route.MapGroup("/api/overview");

        overviewEndpoints.MapGet("/user/{id:int}", GetOverviewAsync);
        overviewEndpoints.MapGet("/user/{id:int}/graph", GetGraphAsync);


        var accountEnpoints = route.MapGroup("/api/accountsoverview");

        accountEnpoints.MapGet("/user/{uId:int}", GetGraphsAsync);

        return route;
    }
    private static async Task<Ok<IEnumerable<AccountDTO>>> GetOverviewAsync(int id, IFrontService data)
    {
        var accountDto = await data.GetOverviewAsync(id);
        return TypedResults.Ok(accountDto);
    }
    private static async Task<Ok<IEnumerable<GraphSnapshotDTO>>> GetGraphAsync(int id, IFrontService data)
    {
        var graphDto = await data.GetOverviewGraphAsync(id);
        return TypedResults.Ok(graphDto);
    }
    private static async Task<Ok<IEnumerable<GraphSnapshotDTO>>> GetGraphsAsync(int uId, IFrontService data)
    {
        var graphDto = await data.GetGraphsByUserIdAsync(uId);
        return TypedResults.Ok(graphDto);
    }
}
