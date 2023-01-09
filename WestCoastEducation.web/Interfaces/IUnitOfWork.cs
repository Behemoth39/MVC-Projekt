namespace WestCoastEducation.web.Interfaces;

public interface IUnitOfWork
{
    ICourseRepository CourseRepository { get; }
    Task<bool> Complete();
}
