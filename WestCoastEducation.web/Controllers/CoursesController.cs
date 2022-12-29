using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Data;

namespace WestCoastEducation.web.Controllers;

[Route("courses")]
public class CoursesController : Controller
{
    private readonly WestCoastEducationContext _context;
    public CoursesController(WestCoastEducationContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {        
        var courses = await _context.Courses.ToListAsync();
        return View("Index", courses);
    }

    [Route("course/{courseName}")]
    public IActionResult Details(string courseName)
    {             
        return View("course");
    }
}
