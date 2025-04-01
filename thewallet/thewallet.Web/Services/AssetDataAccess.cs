using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Services;

namespace thewallet.Web.Services;

public class AssetDataAccess : IAssetService
{
    private readonly string _connectionString = "";
    public AssetDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }
    public async Task<IEnumerable<Asset>> GetAllAsync()
    {
        const string query = """

            SELECT
            id          as Id,
            symbol      as Symbol,
            name        as Name,
            current_value_eur as CurrentValueEur,
            value_timestamp as ValueTimestamp
            FROM public.assets;

            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<Asset>(query);
    }
    public async Task<Asset?> GetByIdAsync(int id)
    {
        const string query = """
            SELECT
            id          as Id,
            symbol      as Symbol,
            name        as Name,
            current_value_eur as CurrentValueEur,
            value_timestamp as ValueTimestamp
            FROM public.assets
            WHERE id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Asset>(query, new { id });
    }
    public async Task<int> CreateAsync(Asset asset)
    {
        const string query = """
            INSERT INTO public.assets
            (symbol,
            name,
            current_value_eur,
            value_timestamp)
            VALUES
            (@Symbol,
            @Name,
            @CurrentValueEur
            now())
            RETURNING id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        asset.Id = await connection.ExecuteScalarAsync<int>(query, asset);
        return asset.Id;
    }
    public async Task<bool> UpdateAsync(Asset asset)
    {
        const string query = """
            UPDATE public.assets
            SET
            symbol = @Symbol,
            name = @Name,
            current_value_eur = @CurrentValueEur,
            value_timestamp = now()
            WHERE
            id = @Id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, asset);
        return affectedRows > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        const string query = """
            DELETE FROM public.assets
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
            FROM public.assets;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query);
    }
}
