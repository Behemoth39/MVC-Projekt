using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Data;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Controllers;

[Route("course/admin")]
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

    [HttpGet("edit/{courseId}")]
     public async Task<IActionResult> Edit(int courseId)
    {
        var course = await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == courseId);
        if(course is not null) return View("Edit", course);
        return Content("Något gick fel!");
    }

    [HttpPost("edit/{courseId}")]
     public async Task<IActionResult> Edit(int courseId, Course course)
    {    
        var courseToUpdate = await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == courseId);
        if(courseToUpdate is null) return RedirectToAction(nameof(Index));

        courseToUpdate.CourseName = course.CourseName;
        courseToUpdate.CourseNumber = course.CourseNumber;
        courseToUpdate.EnrollmentLimit = course.EnrollmentLimit;
        courseToUpdate.CourseStart = course.CourseStart;
        courseToUpdate.CourseEnd = course.CourseEnd;

        _context.Courses.Update(courseToUpdate);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

     [Route("delete/{courseId}")]
     public async Task<IActionResult> Delete(int courseId)
    {
        var courseToDelete = await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == courseId);
        if(courseToDelete is  null) return RedirectToAction(nameof(Index));

        _context.Courses.Remove(courseToDelete);
        await _context.SaveChangesAsync();  

        return RedirectToAction(nameof(Index));      
    }
}
