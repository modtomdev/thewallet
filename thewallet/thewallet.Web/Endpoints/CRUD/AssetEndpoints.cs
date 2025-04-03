using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Endpoints.CRUD;

public static class AssetEndpoints
{
    public static IEndpointRouteBuilder MapAssetEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/assets");
        endpoints.MapGet("/", GetAllAsync);
        endpoints.MapGet("/{id:int}", GetByIdAsync);
        endpoints.MapPost("/", CreateAsync);
        endpoints.MapPut("/{id:int}", UpdateAsync);
        endpoints.MapDelete("/{id:int}", DeleteAsync);
        endpoints.MapGet("/count", GetCountAsync);
        return route;
    }
    private static async Task<Ok<IEnumerable<Asset>>> GetAllAsync(IAssetService data)
    {
        var assets = await data.GetAllAsync();
        return TypedResults.Ok(assets);
    }
    private static async Task<Results<Ok<Asset>, NotFound>> GetByIdAsync(int id, IAssetService data)
    {
        var asset = await data.GetByIdAsync(id);
        if (asset is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(asset);
    }
    private static async Task<Created<Asset>> CreateAsync(Asset asset, IAssetService data)
    {
        asset.Id = await data.CreateAsync(asset);
        return TypedResults.Created($"/thewalletapi/assets/{asset.Id}", asset);
    }
    private static async Task<Results<NoContent, NotFound>> UpdateAsync(int id, Asset asset, IAssetService data)
    {
        if (await data.UpdateAsync(asset))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Results<NoContent, NotFound>> DeleteAsync(int id, IAssetService data)
    {
        if (await data.DeleteAsync(id))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Ok<int>> GetCountAsync(IAssetService data)
    {
        var count = await data.GetCountAsync();
        return TypedResults.Ok(count);
    }
}
