using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.Repository;

namespace WestCoastEducation.web.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly WestCoastEducationContext _context;
    public UnitOfWork(WestCoastEducationContext context)
    {
        _context = context;
    }

    public ICourseRepository CourseRepository => new CourseRepository(_context);

    public IUserRepository UserRepository => new UserRepository(_context);

    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
