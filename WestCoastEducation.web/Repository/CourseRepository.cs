using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Data;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Repository;

public class CourseRepository : Repository<CourseModel>, ICourseRepository
{
    public CourseRepository(WestCoastEducationContext context) : base(context) { }

    public async Task<CourseModel?> FindByCourseNameAsync(string courseName)
    {
        return await _context.Courses.SingleOrDefaultAsync(c => c.CourseName.Trim().ToLower() == courseName.Trim().ToLower());
    }
}
