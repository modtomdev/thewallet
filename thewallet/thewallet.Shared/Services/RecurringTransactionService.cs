namespace thewallet.Web.Client.Services.DomainServices;

using System.Collections.Generic;
using System.Threading.Tasks;
using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Services;

public class RecurringTransactionService : IRecurringTransactionService
{
    public Task<int> CreateAsync(RecurringTransaction recurringTransaction)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RecurringTransaction>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RecurringTransaction?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(RecurringTransaction recurringTransaction)
    {
        throw new NotImplementedException();
    }
}
