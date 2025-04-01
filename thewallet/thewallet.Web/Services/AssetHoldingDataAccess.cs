using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Services;

namespace thewallet.Web.Services;

public class AssetHoldingDataAccess : IAssetHoldingService
{
    private readonly string _connectionString = "";
    public AssetHoldingDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }

    public async Task<IEnumerable<AssetHolding>> GetAllAsync()
    {
        const string query = """

            SELECT
            id              as Id,
            account_id      as AccountId,
            asset_id        as AssetId,
            quantity        as Quantity,
            purchase_date   as PurchaseDate
            FROM public.asset_holdings;

            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<AssetHolding>(query);
    }
    public async Task<AssetHolding?> GetByIdAsync(int id)
    {
        const string query = """
            SELECT
            id              as Id,
            account_id      as AccountId,
            asset_id        as AssetId,
            quantity        as Quantity,
            purchase_date   as PurchaseDate
            FROM public.asset_holdings
            WHERE id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<AssetHolding>(query, new { id });
    }
    public async Task<int> CreateAsync(AssetHolding assetHolding)
    {
        const string query = """
            INSERT INTO public.asset_holdings
            (account_id,
            asset_id,
            quantity,
            purchase_date)
            VALUES
            (@AccountId,
            @AssetId,
            @Quantity,
            @PurchaseDate)
            RETURNING id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        assetHolding.Id = await connection.ExecuteScalarAsync<int>(query, assetHolding);
        return assetHolding.Id;
    }
    public async Task<bool> UpdateAsync(AssetHolding assetHolding)
    {
        const string query = """
            UPDATE public.assets_holdings
            SET
            account_id = @AccountId,
            asset_id = @AssetId,
            quantity = @Quantity,
            purchase_date = @PurchaseDate
            WHERE
            id = @Id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, assetHolding);
        return affectedRows > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        const string query = """
            DELETE FROM public.asset_holdings
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
            FROM public.asset_holdings;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query);
    }
}
