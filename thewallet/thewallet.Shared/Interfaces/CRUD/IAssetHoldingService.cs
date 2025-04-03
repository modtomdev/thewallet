using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Interfaces.CRUD;

public interface IAssetHoldingService
{
    Task<IEnumerable<AssetHolding>> GetAllAsync();
    Task<AssetHolding?> GetByIdAsync(int assetHoldingId);
    Task<int> CreateAsync(AssetHolding assetHolding);
    Task<bool> UpdateAsync(AssetHolding assetHolding);
    Task<bool> DeleteAsync(int assetHoldingId);
    Task<int> GetCountAsync();
}
