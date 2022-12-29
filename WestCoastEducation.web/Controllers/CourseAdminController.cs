using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Data;

namespace WestCoastEducation.web.Controllers;

[Route("courseadmin")]
public class CourseAdminController : Controller
{
    private readonly WestCoastEducationContext _context;
    public CourseAdminController(WestCoastEducationContext context)
    {        
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses.ToListAsync(); 
        return View("Index", courses);
    }
}
