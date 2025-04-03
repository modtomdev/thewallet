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

    public async Task<IEnumerable<AccountDTO>> GetOverviewAsync() //fixed on user1 //optimize method reusage
    {
        const string query = """

            SELECT 
            a.id AS AccountId,
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
    public async Task<IEnumerable<GraphSnapshotDTO>> GetGraphByUserIdAsync(int accountId) //fixed on user1
    {
        const string query = """

            SELECT
                graph_time as SnapshotTimestamp,
                account_value_eur as TotalValueEur 
            FROM graph_snapshots
            WHERE account_id = @accountId;
              
            """;
        //review
        //review
        //review
        //review
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<GraphSnapshotDTO>(query, new { accountId });
    }
}
