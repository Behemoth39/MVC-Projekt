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

    public async Task<bool> AddAsync(UserModel user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Task<bool> DeleteAsync(UserModel user)
    {
        try
        {
            _context.Users.Remove(user);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    public async Task<UserModel?> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<UserModel?> FindByUserNameAsync(string userName)
    {
        return await _context.Users.SingleOrDefaultAsync(c => c.UserName.Trim().ToLower() == userName.Trim().ToLower());
    }

    public async Task<IList<UserModel>> ListAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> SaveAsync()
    {
        try
        {
            if (await _context.SaveChangesAsync() > 0) return true;
            return false;
        }
        catch
        {
            return false;
        }
    }

    public Task<bool> UpdateAsync(UserModel user)
    {
        try
        {
            _context.Users.Update(user);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
}
