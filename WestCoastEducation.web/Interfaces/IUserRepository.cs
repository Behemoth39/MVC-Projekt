using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Interfaces;

public interface IUserRepository
{
    Task<IList<UserModel>> ListAllAsync();
    Task<UserModel?> FindByIdAsync(int id);
    Task<UserModel?> FindByUserNameAsync(string UserName);
    Task<bool> AddAsync(UserModel user);
    Task<bool> UpdateAsync(UserModel user);
    Task<bool> DeleteAsync(UserModel user);
    Task<bool> SaveAsync();
}
