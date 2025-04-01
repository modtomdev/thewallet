using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Services;

namespace thewallet.Web.Client.Services.DomainServices;

public class AssetHoldingService : IAssetHoldingService
{
    public Task<int> CreateAsync(AssetHolding assetHolding)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int assetHoldingId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AssetHolding>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AssetHolding?> GetByIdAsync(int assetHoldingId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(AssetHolding assetHolding)
    {
        throw new NotImplementedException();
    }
}
