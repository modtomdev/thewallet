using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Services.CRUD;

public class CategoryService : ICategoryService
{
    public Task<int> CreateAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetByIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }
}
