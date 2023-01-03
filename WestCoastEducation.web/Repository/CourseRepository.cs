using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Data;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly WestCoastEducationContext _context;
    public CourseRepository(WestCoastEducationContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(CourseModel course)
    {
        try
        {
            await _context.Courses.AddAsync(course);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Task<bool> DeleteAsync(CourseModel course)
    {
        try
        {
            _context.Courses.Remove(course);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
    public async Task<CourseModel?> FindByIdAsync(int id)
    {
        return await _context.Courses.FindAsync(id);
    }
    public async Task<CourseModel?> FindByCourseNameAsync(string courseName)
    {
        return await _context.Courses.SingleOrDefaultAsync(c => c.CourseName.Trim().ToLower() == courseName.Trim().ToLower());
    }

    public async Task<IList<CourseModel>> ListAllAsync()
    {
        return await _context.Courses.ToListAsync();
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

    public Task<bool> UpdateAsync(CourseModel course)
    {
        try
        {
            _context.Courses.Update(course);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
}
