using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Interfaces.CRUD;

public interface IAssetService
{
    Task<IEnumerable<Asset>> GetAllAsync();
    Task<Asset?> GetByIdAsync(int assetId);
    Task<int> CreateAsync(Asset asset);
    Task<bool> UpdateAsync(Asset asset);
    Task<bool> DeleteAsync(int assetId);
    Task<int> GetCountAsync();
}
