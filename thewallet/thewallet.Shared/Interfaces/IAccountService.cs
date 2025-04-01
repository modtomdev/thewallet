using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Services;

public interface IAccountService
{
    Task<IEnumerable<Account>> GetAllAsync();
    Task<Account?> GetByIdAsync(int accountId);
    Task<int> CreateAsync(Account account);
    Task<bool> UpdateAsync(Account account);
    Task<bool> DeleteAsync(int accountId);
    Task<int> GetCountAsync();
}
