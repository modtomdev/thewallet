using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Services;

public interface IRecurringTransactionService
{
    Task<IEnumerable<RecurringTransaction>> GetAllAsync();
    Task<RecurringTransaction?> GetByIdAsync(int id);
    Task<int> CreateAsync(RecurringTransaction recurringTransaction);
    Task<bool> UpdateAsync(RecurringTransaction recurringTransaction);
    Task<bool> DeleteAsync(int id);
    Task<int> GetCountAsync();
}
