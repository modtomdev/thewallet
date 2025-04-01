namespace thewallet.Shared.Models.DomainModels;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string PasswordSalt { get; set; } = default!;
    public string? CmcApiKey { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<Category> UserCategories { get; set; } = [];
    public IEnumerable<Account> UserAccounts { get; set; } = [];
}
