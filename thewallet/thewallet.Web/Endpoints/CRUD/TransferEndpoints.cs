using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Endpoints.CRUD;

public static class TransferEndpoints
{
    public static IEndpointRouteBuilder MapTransferEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/api/transfers");
        endpoints.MapGet("/", GetAllAsync);
        endpoints.MapGet("/{id:int}", GetByIdAsync);
        endpoints.MapPost("/", CreateAsync);
        endpoints.MapPut("/{id:int}", UpdateAsync);
        endpoints.MapDelete("/{id:int}", DeleteAsync);
        endpoints.MapGet("/count", GetCountAsync);
        return route;
    }
    private static async Task<Ok<IEnumerable<Transfer>>> GetAllAsync(ITransferService data)
    {
        var transfers = await data.GetAllAsync();
        return TypedResults.Ok(transfers);
    }
    private static async Task<Results<Ok<Transfer>, NotFound>> GetByIdAsync(int id, ITransferService data)
    {
        var transfer = await data.GetByIdAsync(id);
        if (transfer is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(transfer);
    }
    private static async Task<Created<Transfer>> CreateAsync(Transfer transfer, ITransferService data)
    {
        transfer.Id = await data.CreateAsync(transfer);
        return TypedResults.Created($"/thewalletapi/transfers/{transfer.Id}", transfer);
    }
    private static async Task<Results<NoContent, NotFound>> UpdateAsync(int id, Transfer transfer, ITransferService data)
    {
        if (await data.UpdateAsync(transfer))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Results<NoContent, NotFound>> DeleteAsync(int id, ITransferService data)
    {
        if (await data.DeleteAsync(id))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Ok<int>> GetCountAsync(ITransferService data)
    {
        var count = await data.GetCountAsync();
        return TypedResults.Ok(count);
    }
}
