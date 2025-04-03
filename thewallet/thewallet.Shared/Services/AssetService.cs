using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Client.Services.DomainServices;

public class AssetService : IAssetService
{
    public Task<int> CreateAsync(Asset asset)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int assetId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Asset>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Asset?> GetByIdAsync(int assetId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Asset asset)
    {
        throw new NotImplementedException();
    }
}
