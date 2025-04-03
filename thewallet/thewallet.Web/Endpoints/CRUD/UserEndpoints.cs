using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Endpoints.CRUD;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/users");
        endpoints.MapGet("/", GetAllAsync);
        endpoints.MapGet("/{id:int}", GetByIdAsync);
        endpoints.MapPost("/", CreateAsync);
        endpoints.MapPut("/{id:int}", UpdateAsync);
        endpoints.MapDelete("/{id:int}", DeleteAsync);
        endpoints.MapGet("/count", GetCountAsync);
        return route;
    }
    private static async Task<Ok<IEnumerable<User>>> GetAllAsync(IUserService data)
    {
        var users = await data.GetAllAsync();
        return TypedResults.Ok(users);
    }
    private static async Task<Results<Ok<User>, NotFound>> GetByIdAsync(int id, IUserService data)
    {
        var user = await data.GetByIdAsync(id);
        if (user is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(user);
    }
    private static async Task<Created<User>> CreateAsync(User user, IUserService data)
    {
        user.Id = await data.CreateAsync(user);
        return TypedResults.Created($"/thewalletapi/users/{user.Id}", user);
    }
    private static async Task<Results<NoContent, NotFound>> UpdateAsync(int id, User user, IUserService data)
    {
        if (await data.UpdateAsync(user))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Results<NoContent, NotFound>> DeleteAsync(int id, IUserService data)
    {
        if (await data.DeleteAsync(id))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Ok<int>> GetCountAsync(IUserService data)
    {
        var count = await data.GetCountAsync();
        return TypedResults.Ok(count);
    }
}