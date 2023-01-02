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
        try
        {
            var courses = await _context.Courses.ToListAsync(); 
            return View("Index", courses);
            
        }
        catch (Exception ex)
        {
            var error = new ErrorModel{
                ErrorTitle = "Fel vid inläsning!",
                ErrorMessage = ex.Message
            };
            return View("_Error", error);          
        }
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
        try
        {
             var exists = _context.Courses.SingleOrDefaultAsync(
            c => c.CourseName.Trim().ToLower() == course.CourseName.Trim().ToLower());

            if (exists is not null)
            {
                var error = new ErrorModel{
                ErrorTitle = "Något gick fel!",
                ErrorMessage = $"Kursen {course.CourseName} existerar redan"
                };
                return View("_Error", error); 
            }  
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));          
        }
        catch (Exception ex)
        {
            var error = new ErrorModel{
                ErrorTitle = "Fel vid sparande!",
                ErrorMessage = ex.Message
            };
            return View("_Error", error);          
        }   
        
    }

    [HttpGet("edit/{courseId}")]
     public async Task<IActionResult> Edit(int courseId)
    {
        try
        {
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == courseId);
            if(course is not null) return View("Edit", course);
            var error = new ErrorModel{
                ErrorTitle = "Fel vid inläsning av id!",
                ErrorMessage = $"Kursen med id {courseId} existerar inte"
            };
            
            return View("_Error", error);
        }
        catch (Exception ex)
        {
            var error = new ErrorModel{
                ErrorTitle = "Fel vid inläsning!",
                ErrorMessage = ex.Message
            };
            return View("_Error", error);          
        }                   
    }

    [HttpPost("edit/{courseId}")]
     public async Task<IActionResult> Edit(int courseId, Course course)
    {  
        try
        {
            var courseToUpdate = await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == courseId);
            if(courseToUpdate is null) return RedirectToAction(nameof(Index));

            courseToUpdate.CourseName = course.CourseName;
            courseToUpdate.CourseNumber = course.CourseNumber;
            courseToUpdate.CourseTitle = course.CourseTitle;
            courseToUpdate.CourseStart = course.CourseStart;
            courseToUpdate.CourseLenght = course.CourseLenght;

            _context.Courses.Update(courseToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));            
        }
         catch (Exception ex)
        {
            var error = new ErrorModel{
                ErrorTitle = "Fel vid Sparande!",
                ErrorMessage = ex.Message
            };
            return View("_Error", error);          
        }   
    }

     [Route("delete/{courseId}")]
     public async Task<IActionResult> Delete(int courseId)
    {
        try
        {
            var courseToDelete = await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == courseId);
            if(courseToDelete is  null) return RedirectToAction(nameof(Index));

            _context.Courses.Remove(courseToDelete);
            await _context.SaveChangesAsync();  

            return RedirectToAction(nameof(Index));  
        }
          catch (Exception ex)
        {
            var error = new ErrorModel{
                ErrorTitle = "Fel vid raderandet!",
                ErrorMessage = ex.Message
            };
            return View("_Error", error);          
        }             
    }
}
