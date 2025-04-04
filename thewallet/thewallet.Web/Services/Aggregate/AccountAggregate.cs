using Dapper;
using Npgsql;
using thewallet.Shared.Interfaces.Aggregates;
using thewallet.Shared.Models.DTOs;

namespace thewallet.Web.Services.Aggregate;

public class AccountAggregate : IAccountAggregateService
{
    private readonly string _connectionString = "";
    public AccountAggregate(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }

    public async Task<IEnumerable<GraphSnapshotDTO>> GetGraphsByUserIdAsync(int id)
    {
        const string query =
            """

            SELECT 
                gs.account_id AS AccountId,
                gs.account_value_eur AS TotalValueEur,
                gs.graph_time AS SnapshotTimestamp
            FROM 
                graph_snapshots gs
            INNER JOIN 
                accounts a ON gs.account_id = a.id
            WHERE 
                a.user_id = @id
            ORDER BY 
                gs.graph_time ASC";

            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<GraphSnapshotDTO>(query, new { id });
    }
}
