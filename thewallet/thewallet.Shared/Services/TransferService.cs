using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Services;

namespace thewallet.Web.Client.Services.DomainServices;

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
