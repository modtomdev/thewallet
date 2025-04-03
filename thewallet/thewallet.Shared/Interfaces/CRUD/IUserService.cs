using thewallet.Shared.Models.DomainModels;

namespace thewallet.Shared.Interfaces.CRUD;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int userId);
    Task<int> CreateAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(int userId);
    Task<int> GetCountAsync();
}
