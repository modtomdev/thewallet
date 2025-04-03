using Microsoft.AspNetCore.Http.HttpResults;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Endpoints;

public static class RecurringTransactionEndpoints
{
    public static IEndpointRouteBuilder MapRecurringTransactionEndpoints(this IEndpointRouteBuilder route)
    {
        var endpoints = route.MapGroup("/thewalletapi/recurring");
        endpoints.MapGet("/", GetAllAsync);
        endpoints.MapGet("/{id:int}", GetByIdAsync);
        endpoints.MapPost("/", CreateAsync);
        endpoints.MapPut("/{id:int}", UpdateAsync);
        endpoints.MapDelete("/{id:int}", DeleteAsync);
        endpoints.MapGet("/count", GetCountAsync);
        return route;
    }
    private static async Task<Ok<IEnumerable<RecurringTransaction>>> GetAllAsync(IRecurringTransactionService data)
    {
        var recurringTransactions = await data.GetAllAsync();
        return TypedResults.Ok(recurringTransactions);
    }
    private static async Task<Results<Ok<RecurringTransaction>, NotFound>> GetByIdAsync(int id, IRecurringTransactionService data)
    {
        var recurringTransaction = await data.GetByIdAsync(id);
        if (recurringTransaction is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(recurringTransaction);
    }
    private static async Task<Created<RecurringTransaction>> CreateAsync(RecurringTransaction recurringTransaction, IRecurringTransactionService data)
    {
        recurringTransaction.Id = await data.CreateAsync(recurringTransaction);
        return TypedResults.Created($"/thewalletapi/recurring/{recurringTransaction.Id}", recurringTransaction);
    }
    private static async Task<Results<NoContent, NotFound>> UpdateAsync(int id, RecurringTransaction recurringTransaction, IRecurringTransactionService data)
    {
        if (await data.UpdateAsync(recurringTransaction))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Results<NoContent, NotFound>> DeleteAsync(int id, IRecurringTransactionService data)
    {
        if (await data.DeleteAsync(id))
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
    private static async Task<Ok<int>> GetCountAsync(IRecurringTransactionService data)
    {
        var count = await data.GetCountAsync();
        return TypedResults.Ok(count);
    }
}
