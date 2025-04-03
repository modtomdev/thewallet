using System.Security.Principal;
using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Endpoints;

public static class AccountEndpoints
{
    public static IEndpointRouteBuilder MapAccountEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/accounts");

        endpoints.MapGet("/", GetAllAsync);
        endpoints.MapGet("/{id:int}", GetByIdAsync);
        endpoints.MapPost("/", CreateAsync);
        endpoints.MapPut("/{id:int}", UpdateAsync);
        endpoints.MapDelete("/{id:int}", DeleteAsync);
        endpoints.MapGet("/count", GetCountAsync);

        return route;
    }

    private static async Task<Ok<IEnumerable<Account>>> GetAllAsync(IAccountService data)
    {
        var accounts = await data.GetAllAsync();
        return TypedResults.Ok(accounts);
    }
    private static async Task<Results<Ok<Account>, NotFound>> GetByIdAsync(int id, IAccountService data)
    {
        var account = await data.GetByIdAsync(id);
        if (account is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(account);
    }
    private static async Task<Created<Account>> CreateAsync(Account account, IAccountService data)
    {
        account.Id = await data.CreateAsync(account);
        return TypedResults.Created($"/thewalletapi/accounts/{account.Id}", account);
    }
    private static async Task<Results<NoContent, NotFound>> UpdateAsync(int id, Account account, IAccountService data)
    {
        if (await data.UpdateAsync(account))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Results<NoContent, NotFound>> DeleteAsync(int id, IAccountService data)
    {
        if (await data.DeleteAsync(id))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Ok<int>> GetCountAsync(IAccountService data)
    {
        var count = await data.GetCountAsync();
        return TypedResults.Ok(count);
    }
}
