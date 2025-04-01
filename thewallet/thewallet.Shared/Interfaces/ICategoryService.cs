using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int categoryId);
    Task<int> CreateAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteAsync(int categoryId);
    Task<int> GetCountAsync();
}
