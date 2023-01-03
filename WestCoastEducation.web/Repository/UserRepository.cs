using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Data;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Repository;

public class UserRepository : IUserRepository
{
    private readonly WestCoastEducationContext _context;
    public UserRepository(WestCoastEducationContext context)
    {
        _context = context;
    }

    public Task<bool> AddAsync(UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel?> FindByUserNameAsync(string UserName)
    {
        throw new NotImplementedException();
    }

    public Task<IList<UserModel>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(UserModel user)
    {
        throw new NotImplementedException();
    }
}
