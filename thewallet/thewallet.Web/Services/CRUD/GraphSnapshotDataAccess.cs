using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Interfaces.CRUD;

namespace thewallet.Web.Services.CRUD;

public class GraphSnapshotDataAccess : IGraphSnapshotService
{
    private readonly string _connectionString = "";
    public GraphSnapshotDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }
    public async Task<IEnumerable<GraphSnapshot>> GetAllAsync()
    {
        const string query = """
            SELECT
            id          as Id,
            account_id  as AccountId,
            graph_time as GraphTime,
            account_value_eur as AccountValueEur
            FROM public.graph_snapshots;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<GraphSnapshot>(query);
    }
    public async Task<GraphSnapshot?> GetByIdAsync(int id)
    {
        const string query = """
            SELECT
            id          as Id,
            account_id  as AccountId,
            graph_time as GraphTime,
            account_value_eur as AccountValueEur
            FROM public.graph_snapshots
            WHERE id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<GraphSnapshot>(query, new { id });
    }
    public async Task<int> CreateAsync(GraphSnapshot graphSnapshot)
    {
        const string query = """
            INSERT INTO public.graph_snapshots
            (account_id,
            graph_time,
            account_value_eur)
            VALUES
            (@AccountId,
            @GraphTime,
            @AccountValueEur)
            RETURNING id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        graphSnapshot.Id = await connection.ExecuteScalarAsync<int>(query, graphSnapshot);
        return graphSnapshot.Id;
    }
    public async Task<bool> UpdateAsync(GraphSnapshot graphSnapshot)
    {
        const string query = """
            UPDATE public.graph_snapshots
            SET
            account_id = @AccountId,
            graph_time = @GraphTime,
            account_value_eur = @AccountValueEur
            WHERE
            id = @Id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, graphSnapshot);
        return affectedRows > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        const string query = """
            DELETE FROM public.graph_snapshots
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
            FROM public.graph_snapshots;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query);

    }
    public async Task<IEnumerable<GraphSnapshot>> GetByAccountIdAsync(int id)
    {
        const string query = """
            SELECT
            id          as Id,
            account_id  as AccountId,
            graph_time as GraphTime,
            account_value_eur as AccountValueEur
            FROM public.graph_snapshots
            WHERE account_id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<GraphSnapshot>(query, new { id });
    }
}
