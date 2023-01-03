using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Data;

 public class WestCoastEducationContext : DbContext
{
    public DbSet<CourseModel> Courses => Set<CourseModel>();
    public DbSet<UserModel> Users => Set<UserModel>();
    public WestCoastEducationContext(DbContextOptions options) : base(options){ }
}
