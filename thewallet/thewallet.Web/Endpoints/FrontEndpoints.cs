using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs;
using thewallet.Web.Components;

namespace thewallet.Web.Endpoints;

public static class FrontEndpoints
{
    public static IEndpointRouteBuilder MapFrontEndpoints(this IEndpointRouteBuilder route)
    {

        var overviewEndpoints = route.MapGroup("/api/overview");

        overviewEndpoints.MapGet("/user/{id:int}", GetOverviewAsync);
        overviewEndpoints.MapGet("/user/{id:int}/graph", GetGraphAsync);


        var accountOverviewEnpoints = route.MapGroup("/api/accountsoverview");

        accountOverviewEnpoints.MapGet("/user/{uId:int}", GetGraphsAsync);

        var accountDetailsEndpoints = route.MapGroup("/api/accountdetails");
        accountDetailsEndpoints.MapGet("/user/{userId:int}/account/{accountId:int}", GetSingleOverviewAsync);

        return route;
    }

    private static async Task<Results<Ok<AccountDTO>,NotFound>> GetSingleOverviewAsync(int userId, int accountId, IFrontService data)
    {
        var accountDTO = await data.GetSingleOverviewAsync(userId, accountId);
        if(accountDTO is not null)
        {
            return TypedResults.Ok(accountDTO);
        }
        return TypedResults.NotFound();
    }

    private static async Task<Ok<IEnumerable<AccountDTO>>> GetOverviewAsync(int id, IFrontService data)
    {
        var accountDTOs = await data.GetOverviewAsync(id);
        return TypedResults.Ok(accountDTOs);
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
