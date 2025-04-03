using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Services.CRUD;

public class TransferService : ITransferService
{
    public Task<int> CreateAsync(Transfer transfer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int transferId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Transfer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Transfer?> GetByIdAsync(int transferId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Transfer transfer)
    {
        throw new NotImplementedException();
    }
}
