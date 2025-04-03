using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Client.Services.DomainServices;

public class AccountService : IAccountService
{
    public Task<int> CreateAsync(Account account)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int accountId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Account>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Account?> GetByIdAsync(int accountId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Account account)
    {
        throw new NotImplementedException();
    }
}
