using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Services;

namespace thewallet.Web.Services;

public class CategoryDataAccess : ICategoryService
{
    private readonly string _connectionString = "";
    public CategoryDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") ??
                                throw new Exception("Missing db connection string.");
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        const string query = """

            SELECT
            id          as Id,
            name        as Name,
            user_id     as UserId,
            is_expense  as IsExpense,
            created_at  as CreatedAt
            FROM public.categories;

            """;

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<Category>(query);
    }
    public async Task<Category?> GetByIdAsync(int id)
    {
        const string query = """
            SELECT
            id          as Id,
            name        as Name,
            user_id     as UserId,
            is_expense  as IsExpense,
            created_at  as CreatedAt
            FROM public.categories
            WHERE id = @id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Category>(query, new { id });
    }
    public async Task<int> CreateAsync(Category category)
    {
        const string query = """
            INSERT INTO public.categories
            (name,
            user_id,
            is_expense,
            created_at)
            VALUES
            (@Name,
            @UserId,
            @IsExpense,
            now())
            RETURNING id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        category.Id = await connection.ExecuteScalarAsync<int>(query, category);
        return category.Id;
    }
    public async Task<bool> UpdateAsync(Category category)
    {
        const string query = """
            UPDATE public.categories
            SET
            name = @Name,
            user_id = @UserId,
            is_expense = @IsExpense,
            WHERE
            id = @Id;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, category);
        return affectedRows > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        const string query = """
            DELETE FROM public.categories
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
            FROM public.categories;
            """;
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(query);
    }
}
