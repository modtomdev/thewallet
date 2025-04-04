using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Endpoints.CRUD;

public static class GraphSnapshotEndpoints
{
    public static IEndpointRouteBuilder MapGraphSnapshotEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/api/graphsnapshots");

        endpoints.MapGet("/", GetAllAsync);
        endpoints.MapGet("/{id:int}", GetByIdAsync);
        endpoints.MapPost("/", CreateAsync);
        endpoints.MapPut("/{id:int}", UpdateAsync);
        endpoints.MapDelete("/{id:int}", DeleteAsync);
        endpoints.MapGet("/count", GetCountAsync);
        endpoints.MapGet("/account{accountId:int}", GetByAccountIdAsync);

        return route;
    }
    private static async Task<Ok<IEnumerable<GraphSnapshot>>> GetAllAsync(IGraphSnapshotService data)
    {
        var graphSnapshots = await data.GetAllAsync();
        return TypedResults.Ok(graphSnapshots);
    }
    private static async Task<Results<Ok<GraphSnapshot>, NotFound>> GetByIdAsync(int id, IGraphSnapshotService data)
    {
        var graphSnapshot = await data.GetByIdAsync(id);
        if (graphSnapshot is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(graphSnapshot);
    }
    private static async Task<Created<GraphSnapshot>> CreateAsync(GraphSnapshot graphSnapshot, IGraphSnapshotService data)
    {
        graphSnapshot.Id = await data.CreateAsync(graphSnapshot);
        return TypedResults.Created($"/thewalletapi/graphsnapshots/{graphSnapshot.Id}", graphSnapshot);
    }
    private static async Task<Results<NoContent, NotFound>> UpdateAsync(int id, GraphSnapshot graphSnapshot, IGraphSnapshotService data)
    {
        if (await data.UpdateAsync(graphSnapshot))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Results<NoContent, NotFound>> DeleteAsync(int id, IGraphSnapshotService data)
    {
        if (await data.DeleteAsync(id))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Ok<int>> GetCountAsync(IGraphSnapshotService data)
    {
        var count = await data.GetCountAsync();
        return TypedResults.Ok(count);
    }
    private static async Task<Ok<IEnumerable<GraphSnapshot>>> GetByAccountIdAsync(int userId, int accountId, IGraphSnapshotService data)
    {
        var graphSnapshots = await data.GetByAccountIdAsync(userId, accountId);
        return TypedResults.Ok(graphSnapshots);
    }
}
