using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Interfaces.CRUD;

namespace thewallet.Web.Services.CRUD;

public class UserDataAccess : IUserService
{
    private readonly string _connectionString = "";
    public UserDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        const string query = """

            SELECT
            id          as Id,
            username    as Username,
            password_hash as PasswordHash,
            salt as PasswordSalt,
            cmc_apikey as CmcApiKey,
            created_at  as CreatedAt
            FROM public.users;

            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<User>(query);
    }
    public async Task<User?> GetByIdAsync(int id)
    {
        const string query = """
            SELECT
            id          as Id,
            username    as Username,
            password_hash as PasswordHash,
            salt as PasswordSalt,
            cmc_apikey as CmcApiKey,
            created_at  as CreatedAt
            FROM public.users
            WHERE id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<User>(query, new { id });
    }
    public async Task<int> CreateAsync(User user)
    {
        const string query = """
            INSERT INTO public.users
            (username,
            password_hash,
            salt,
            cmc_apikey,
            created_at)
            VALUES
            (@Username,
            @PasswordHash,
            @PasswordSalt,
            @CmcApiKey,
            now())
            RETURNING id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        user.Id = await connection.ExecuteScalarAsync<int>(query, user);
        return user.Id;
    }
    public async Task<bool> UpdateAsync(User user)
    {
        const string query = """
            UPDATE public.users
            SET
            username = @Username,
            password_hash = @PasswordHash,
            salt = @PasswordSalt,
            cmc_apikey = @CmcApiKey
            WHERE
            id = @Id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, user);
        return affectedRows > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        const string query = """
            DELETE FROM public.users
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
            FROM public.users;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query);
    }
}
