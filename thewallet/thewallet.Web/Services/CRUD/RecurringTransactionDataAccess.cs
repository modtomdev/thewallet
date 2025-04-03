using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Interfaces.CRUD;

namespace thewallet.Web.Services.CRUD;

public class RecurringTransactionDataAccess : IRecurringTransactionService
{
    private readonly string _connectionString = "";

    public RecurringTransactionDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db")
                                ?? throw new Exception("Missing db connection string.");
    }

    public async Task<IEnumerable<RecurringTransaction>> GetAllAsync()
    {
        const string query = """
            SELECT
            id                  as Id,
            from_account_id     as FromAccountId,
            to_account_id       as ToAccountId,
            asset_id            as AssetId,
            amount              as Amount,
            created_at          as TransferTimestamp
            FROM public.recurring_transactions;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<RecurringTransaction>(query);
    }
    public async Task<RecurringTransaction?> GetByIdAsync(int id)
    {
        const string query = """

            SELECT
            id                  as Id,
            from_account_id     as FromAccountId,
            to_account_id       as ToAccountId,
            asset_id            as AssetId,
            amount              as Amount,
            created_at          as TransferTimestamp
            FROM public.recurring_transactions
            WHERE id = @id;

            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<RecurringTransaction>(query, new { id });
    }
    public async Task<int> CreateAsync(RecurringTransaction recurringTransaction)
    {
        const string query = """

            INSERT INTO public.recurring_transactions
            (from_account_id,
            to_account_id,
            asset_id,
            amount,
            created_at)
            VALUES
            (@FromAccountId,
            @ToAccountId,
            @AssetId,
            @Amount,
            now())
            RETURNING id;

            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query, recurringTransaction);
    }
    public async Task<bool> UpdateAsync(RecurringTransaction recurringTransaction)
    {
        const string query = """

            UPDATE public.recurring_transactions
            SET
            from_account_id = @FromAccountId,
            to_account_id = @ToAccountId,
            asset_id = @AssetId,
            amount = @Amount,
            created_at = @TransferTimestamp
            WHERE id = @Id;

            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, recurringTransaction);
        return affectedRows > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        const string query = """
            DELETE FROM public.recurring_transactions
            WHERE id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, new { id });
        return affectedRows > 0;
    }
    public async Task<int> GetCountAsync()
    {
        const string query = """
            SELECT COUNT(*)
            FROM public.recurring_transactions;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query);
    }
}
