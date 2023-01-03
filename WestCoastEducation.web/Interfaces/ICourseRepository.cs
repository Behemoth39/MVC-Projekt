using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Interfaces;

public interface ICourseRepository
{
    Task<IList<CourseModel>> ListAllAsync();  
    Task<CourseModel?> FindByIdAsync(int id);
    Task<CourseModel?> FindByCourseNameAsync(string CourseName);
    Task<bool> AddAsync(CourseModel course);
    Task<bool> UpdateAsync(CourseModel course);
    Task<bool> DeleteAsync(CourseModel course);
    Task<bool> SaveAsync();
}
