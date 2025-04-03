using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Interfaces.CRUD;

public interface IAccountTransactionService
{
    Task<IEnumerable<AccountTransaction>> GetAllAsync();
    Task<AccountTransaction?> GetByIdAsync(int transactionId);
    Task<int> CreateAsync(AccountTransaction transaction);
    Task<bool> UpdateAsync(AccountTransaction transaction);
    Task<bool> DeleteAsync(int transactionId);
    Task<int> GetCountAsync();
}
