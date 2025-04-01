using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Services;

namespace thewallet.Web.Services;

public class TransferDataAccess : ITransferService
{
    private readonly string _connectionString = "";
    public TransferDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }

    public async Task<IEnumerable<Transfer>> GetAllAsync()
    {
        const string query = """

            SELECT
            id                  as Id,
            from_account_id     as FromAccountId,
            to_account_id       as ToAccountId,
            asset_id            as AssetId,
            amount              as Amount,
            created_at          as TransferTimestamp
            FROM public.transfers;

            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<Transfer>(query);
    }
    public async Task<Transfer?> GetByIdAsync(int id)
    {
        const string query = """
            SELECT
            id          as Id,
            from_account_id as FromAccountId,
            to_account_id as ToAccountId,
            asset_id as AssetId,
            amount as Amount,
            created_at as TransferTimestamp
            FROM public.transfers
            WHERE id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Transfer>(query, new { id });
    }
    public async Task<int> CreateAsync(Transfer transfer)
    {
        const string query = """
            INSERT INTO public.transfers
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
        transfer.Id = await connection.ExecuteScalarAsync<int>(query, transfer);
        return transfer.Id;
    }
    public async Task<bool> UpdateAsync(Transfer transfer)
    {
        const string query = """
            UPDATE public.transfers
            SET
            from_account_id = @FromAccountId,
            to_account_id = @ToAccountId,
            asset_id = @AssetId,
            amount = @Amount,
            created_at = @TransferTimestamp
            WHERE
            id = @Id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, transfer);
        return affectedRows > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        const string query = """
            DELETE FROM public.transfers
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
            FROM public.transfers;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query);
    }
}
