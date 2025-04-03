using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Client.Services.DomainServices;

public class UserService : IUserService
{
    public Task<int> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
