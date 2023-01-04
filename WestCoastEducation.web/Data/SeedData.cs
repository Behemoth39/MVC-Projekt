using System.Text.Json;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Data;

public static class SeedData
{
    public static async Task LoadCourseData(WestCoastEducationContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        if (context.Courses.Any()) return;
        var json = System.IO.File.ReadAllText("Data/Json/courses.json");
        var courses = JsonSerializer.Deserialize<List<CourseModel>>(json, options);

        if (courses is not null && courses.Count > 0)
        {
            await context.Courses.AddRangeAsync(courses);
            await context.SaveChangesAsync();
        }
    }

    /*public static async Task LoadUserData(WestCoastEducationContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        if (context.Courses.Any()) return;
        var json = System.IO.File.ReadAllText("Data/Json/users.json");
        var users = JsonSerializer.Deserialize<List<CourseModel>>(json, options);

        if (users is not null && users.Count > 0)
        {
            await context.Courses.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }*/
}
