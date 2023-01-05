using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Data;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Repository;

public class UserRepository : Repository<UserModel>, IUserRepository
{
    public UserRepository(WestCoastEducationContext context) : base(context) { }

    public async Task<UserModel?> FindByUserNameAsync(string userName)
    {
        return await _context.Users.SingleOrDefaultAsync(c => c.UserName.Trim().ToLower() == userName.Trim().ToLower());
    }
}
