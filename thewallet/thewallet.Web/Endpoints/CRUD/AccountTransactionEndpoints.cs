using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Endpoints.CRUD;

public static class AccountTransactionEndpoints
{
    public static IEndpointRouteBuilder MapAccountTransactionEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/transactions");
        endpoints.MapGet("/", GetAllAsync);
        endpoints.MapGet("/{id:int}", GetByIdAsync);
        endpoints.MapPost("/", CreateAsync);
        endpoints.MapPut("/{id:int}", UpdateAsync);
        endpoints.MapDelete("/{id:int}", DeleteAsync);
        endpoints.MapGet("/count", GetCountAsync);
        return route;
    }
    private static async Task<Ok<IEnumerable<AccountTransaction>>> GetAllAsync(IAccountTransactionService data)
    {
        var accountTransactions = await data.GetAllAsync();
        return TypedResults.Ok(accountTransactions);
    }
    private static async Task<Results<Ok<AccountTransaction>, NotFound>> GetByIdAsync(int id, IAccountTransactionService data)
    {
        var accountTransaction = await data.GetByIdAsync(id);
        if (accountTransaction is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(accountTransaction);
    }
    private static async Task<Created<AccountTransaction>> CreateAsync(AccountTransaction accountTransaction, IAccountTransactionService data)
    {
        accountTransaction.Id = await data.CreateAsync(accountTransaction);
        return TypedResults.Created($"/thewalletapi/transactions/{accountTransaction.Id}", accountTransaction);
    }
    private static async Task<Results<NoContent, NotFound>> UpdateAsync(int id, AccountTransaction accountTransaction, IAccountTransactionService data)
    {
        if (await data.UpdateAsync(accountTransaction))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Results<NoContent, NotFound>> DeleteAsync(int id, IAccountTransactionService data)
    {
        if (await data.DeleteAsync(id))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Ok<int>> GetCountAsync(IAccountTransactionService data)
    {
        var count = await data.GetCountAsync();
        return TypedResults.Ok(count);
    }
}
