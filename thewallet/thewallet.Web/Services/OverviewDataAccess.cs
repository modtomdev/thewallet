using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Models.DTOs;
using thewallet.Shared.Models.DTOs.Overview;

namespace thewallet.Web.Services;

public class OverviewDataAccess : IOverviewService
{
    private readonly string _connectionString = "";
    public OverviewDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }

    public async Task<IEnumerable<AccountDTO>> GetAccountDTOsAsync() //fixed on user1
    {
        const string query = """

            SELECT 
                a.name AS AccountName, 
            COALESCE(SUM(ah.quantity * ass.current_value_eur), 0) AS TotalValueEur
            FROM accounts a
            LEFT JOIN asset_holdings ah ON a.id = ah.account_id
            LEFT JOIN assets ass ON ah.asset_id = ass.id
            WHERE a.user_id = 1
            GROUP BY a.id, a.name;
            
            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<AccountDTO>(query);
    }
    public async Task<IEnumerable<GraphDTO>> GetGraphDTOsAsync() //fixed on user1
    {
        const string query = """

            SELECT 
            gs.graph_time AS SnapshotTimestamp,
            COALESCE(SUM(gs.account_value_eur), 0) AS TotalValueEur
            FROM graph_snapshots gs
            JOIN accounts a ON gs.account_id = a.id
            WHERE a.user_id = 1
            GROUP BY gs.graph_time
            ORDER BY gs.graph_time ASC;
                
            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<GraphDTO>(query);
    }
}


