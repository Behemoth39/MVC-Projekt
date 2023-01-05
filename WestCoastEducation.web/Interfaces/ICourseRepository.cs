using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Interfaces;

public interface ICourseRepository : IRepository<CourseModel>
{
    Task<CourseModel?> FindByCourseNameAsync(string CourseName);
}
