using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Interfaces;

public interface IUserRepository : IRepository<UserModel>
{
    Task<UserModel?> FindByUserNameAsync(string UserName);
}
