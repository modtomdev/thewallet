using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Services;

namespace thewallet.Web.Services;

public class AccountTransactionDataAccess : IAccountTransactionService
{
    private readonly string _connectionString = "";
    public AccountTransactionDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }
    public async Task<IEnumerable<AccountTransaction>> GetAllAsync()
    {
        const string query = """

            SELECT
            id          as Id,
            account_id  as AccountId,
            category_id as CategoryId,
            asset_id    as AssetId,
            amount      as Amount,
            description as Description,
            created_at  as CreatedAt
            FROM public.transactions;

            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<AccountTransaction>(query);
    }
    public async Task<AccountTransaction?> GetByIdAsync(int id)
    {
        const string query = """
            SELECT
            id          as Id,
            account_id  as AccountId,
            category_id as CategoryId,
            asset_id    as AssetId,
            amount      as Amount,
            description as Description,
            created_at  as CreatedAt
            FROM public.transactions
            WHERE id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<AccountTransaction>(query, new { id });
    }
    public async Task<int> CreateAsync(AccountTransaction accountTransaction)
    {
        const string query = """
            INSERT INTO public.transactions
            (account_id,
            category_id,
            asset_id,
            amount,
            description,
            created_at)
            VALUES
            (@AccountId,
            @CategoryId,
            @AssetId,
            @Amount,
            @Description,
            now())
            RETURNING id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        accountTransaction.Id = await connection.ExecuteScalarAsync<int>(query, accountTransaction);
        return accountTransaction.Id;
    }
    public async Task<bool> UpdateAsync(AccountTransaction accountTransaction)
    {
        const string query = """
            UPDATE public.transactions
            account_id = @AccountId,
            category_id = @CategoryId,
            asset_id = @AssetId,
            amount = @Amount,
            description = @Description,
            WHERE
            id = @Id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, accountTransaction);
        return affectedRows > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        const string query = """
            DELETE FROM public.transactions
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
            FROM public.transactions;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query);
    }
}
