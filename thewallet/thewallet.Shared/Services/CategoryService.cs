using thewallet.Shared.Models.DomainModels;
using thewallet.Shared.Services;

namespace thewallet.Web.Client.Services.DomainServices;

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
