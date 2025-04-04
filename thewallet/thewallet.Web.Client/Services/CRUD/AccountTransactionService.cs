using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Services.CRUD;

public class AccountTransactionService : IAccountTransactionService
{
    public Task<int> CreateAsync(AccountTransaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AccountTransaction>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AccountTransaction?> GetByIdAsync(int transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(AccountTransaction transaction)
    {
        throw new NotImplementedException();
    }
}
