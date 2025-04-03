using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Interfaces.CRUD;

namespace thewallet.Web.Services.CRUD;
public class AccountDataAccess : IAccountService
{
    private readonly string _connectionString = "";
    public AccountDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        const string query = """

            SELECT
            id          as Id,
            user_id     as UserId,
            name        as Name,
            created_at  as CreatedAt
            FROM public.accounts; 

            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<Account>(query);
    }
    public async Task<Account?> GetByIdAsync(int id)
    {
        const string query = """
            SELECT
            id          as Id,
            user_id     as UserId,
            name        as Name,
            created_at  as CreatedAt
            FROM public.accounts
            WHERE id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Account>(query, new { id });
    }
    public async Task<int> CreateAsync(Account account)
    {
        const string query = """
            INSERT INTO public.accounts
            (user_id,
            name,
            created_at)
            VALUES
            (@UserId,
            @Name,
            now())
            RETURNING id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        account.Id = await connection.ExecuteScalarAsync<int>(query, account);
        return account.Id;
    }
    public async Task<bool> UpdateAsync(Account account)
    {
        const string query = """
            UPDATE public.accounts
            SET
            user_id = @UserId,
            name = @Name
            WHERE
            id = @Id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, account);
        return affectedRows > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        const string query = """
            DELETE FROM public.accounts
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
            FROM public.accounts;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query);
    }
}
