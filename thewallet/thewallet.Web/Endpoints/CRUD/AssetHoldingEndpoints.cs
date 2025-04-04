using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Endpoints.CRUD;

public static class AssetHoldingEndpoints
{
    public static IEndpointRouteBuilder MapAssetHoldingEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/api/assetholdings");
        endpoints.MapGet("/", GetAllAsync);
        endpoints.MapGet("/{id:int}", GetByIdAsync);
        endpoints.MapPost("/", CreateAsync);
        endpoints.MapPut("/{id:int}", UpdateAsync);
        endpoints.MapDelete("/{id:int}", DeleteAsync);
        endpoints.MapGet("/count", GetCountAsync);
        return route;
    }
    private static async Task<Ok<IEnumerable<AssetHolding>>> GetAllAsync(IAssetHoldingService data)
    {
        var assetHoldings = await data.GetAllAsync();
        return TypedResults.Ok(assetHoldings);
    }
    private static async Task<Results<Ok<AssetHolding>, NotFound>> GetByIdAsync(int id, IAssetHoldingService data)
    {
        var assetHolding = await data.GetByIdAsync(id);
        if (assetHolding is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(assetHolding);
    }
    private static async Task<Created<AssetHolding>> CreateAsync(AssetHolding assetHolding, IAssetHoldingService data)
    {
        assetHolding.Id = await data.CreateAsync(assetHolding);
        return TypedResults.Created($"/thewalletapi/assetholdings/{assetHolding.Id}", assetHolding);
    }
    private static async Task<Results<NoContent, NotFound>> UpdateAsync(int id, AssetHolding assetHolding, IAssetHoldingService data)
    {
        if (await data.UpdateAsync(assetHolding))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Results<NoContent, NotFound>> DeleteAsync(int id, IAssetHoldingService data)
    {
        if (await data.DeleteAsync(id))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Ok<int>> GetCountAsync(IAssetHoldingService data)
    {
        var count = await data.GetCountAsync();
        return TypedResults.Ok(count);
    }
}
