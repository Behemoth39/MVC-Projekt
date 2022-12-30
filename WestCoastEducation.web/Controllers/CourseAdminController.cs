using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Data;
using WestCoastEducation.web.Models;

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

    [HttpGet("create")]
     public IActionResult Create()
    {
        var course = new Course();
        return View("Create", course);
    }

    [HttpPost("create")]
     public async Task<IActionResult> Create(Course course)
    {    
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
