using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Endpoints.CRUD;

public static class CategoryEndpoints
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/categories");
        endpoints.MapGet("/", GetAllAsync);
        endpoints.MapGet("/{id:int}", GetByIdAsync);
        endpoints.MapPost("/", CreateAsync);
        endpoints.MapPut("/{id:int}", UpdateAsync);
        endpoints.MapDelete("/{id:int}", DeleteAsync);
        endpoints.MapGet("/count", GetCountAsync);
        return route;
    }
    private static async Task<Ok<IEnumerable<Category>>> GetAllAsync(ICategoryService data)
    {
        var categories = await data.GetAllAsync();
        return TypedResults.Ok(categories);
    }
    private static async Task<Results<Ok<Category>, NotFound>> GetByIdAsync(int id, ICategoryService data)
    {
        var category = await data.GetByIdAsync(id);
        if (category is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(category);
    }
    private static async Task<Created<Category>> CreateAsync(Category category, ICategoryService data)
    {
        category.Id = await data.CreateAsync(category);
        return TypedResults.Created($"/thewalletapi/categories/{category.Id}", category);
    }
    private static async Task<Results<NoContent, NotFound>> UpdateAsync(int id, Category category, ICategoryService data)
    {
        if (await data.UpdateAsync(category))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Results<NoContent, NotFound>> DeleteAsync(int id, ICategoryService data)
    {
        if (await data.DeleteAsync(id))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Ok<int>> GetCountAsync(ICategoryService data)
    {
        var count = await data.GetCountAsync();
        return TypedResults.Ok(count);
    }
}
