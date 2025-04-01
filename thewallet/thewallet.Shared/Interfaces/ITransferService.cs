using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Services;

public interface ITransferService
{
    Task<IEnumerable<Transfer>> GetAllAsync();
    Task<Transfer?> GetByIdAsync(int transferId);
    Task<int> CreateAsync(Transfer transfer);
    Task<bool> UpdateAsync(Transfer transfer);
    Task<bool> DeleteAsync(int transferId);
    Task<int> GetCountAsync();
}
