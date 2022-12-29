using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Data;

 public class WestCoastEducationContext : DbContext
{
    public DbSet<Course> Courses => Set<Course>();
    public WestCoastEducationContext(DbContextOptions options) : base(options){ }
}
