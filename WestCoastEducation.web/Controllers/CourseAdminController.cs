using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation.web.Data;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.Models;
using WestCoastEducation.web.ViewModels;

namespace WestCoastEducation.web.Controllers;

[Route("course/admin")]
public class CourseAdminController : Controller
{
    private readonly ICourseRepository _repo;
    public CourseAdminController(ICourseRepository repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var courses = await _repo.ListAllAsync();

            var model = courses.Select(c => new CourseListViewModel
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName,
                CourseNumber = c.CourseNumber,
                CourseTitle = c.CourseTitle,
                CourseStart = c.CourseStart,
                CourseLenght = c.CourseLenght
            }).ToList();

            return View("Index", model);
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Fel vid inläsning!",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        var course = new CoursePostViewModel();
        return View("Create", course);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CoursePostViewModel course)
    {
        try
        {
            if (!ModelState.IsValid) return View("Create", course);

            var exists = await _repo.FindByCourseNameAsync(course.CourseName);

            if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Något gick fel!",
                    ErrorMessage = $"Kursen {course.CourseName} existerar redan"
                };
                return View("_Error", error);
            }

            var courseToAdd = new CourseModel
            {
                CourseName = course.CourseName,
                CourseNumber = course.CourseNumber,
                CourseTitle = course.CourseTitle,
                CourseStart = course.CourseStart,
                CourseLenght = (int)course.CourseLenght!
            };

            if (await _repo.AddAsync(courseToAdd))
            {
                if (await _repo.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var saveError = new ErrorModel
            {
                ErrorTitle = "Något gick fel!",
                ErrorMessage = $"Fel vid sparande av {course.CourseName}!"
            };

            return View("_Error", saveError);
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
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
            var result = await _repo.FindByIdAsync(courseId);

            if (result is null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Fel vid inläsning av id!",
                    ErrorMessage = $"Kursen med id {courseId} existerar inte"
                };

                return View("_Error", error);
            }

            var courseToUpdate = new CourseUpdateViewModel
            {
                CourseId = result.CourseId,
                CourseName = result.CourseName,
                CourseNumber = result.CourseNumber,
                CourseTitle = result.CourseTitle,
                CourseStart = result.CourseStart,
                CourseLenght = result.CourseLenght
            };

            return View("Edit", courseToUpdate);
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Fel vid inläsning!",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }

    [HttpPost("edit/{courseId}")]
    public async Task<IActionResult> Edit(int courseId, CourseUpdateViewModel course)
    {
        try
        {
            if (!ModelState.IsValid) return View("Edit", course);

            var courseToUpdate = await _repo.FindByIdAsync(courseId);

            if (courseToUpdate is null) return RedirectToAction(nameof(Index));

            courseToUpdate.CourseName = course.CourseName;
            courseToUpdate.CourseNumber = course.CourseNumber;
            courseToUpdate.CourseTitle = course.CourseTitle;
            courseToUpdate.CourseStart = course.CourseStart;
            courseToUpdate.CourseLenght = (int)course.CourseLenght!;

            if (await _repo.UpdateAsync(courseToUpdate))
            {
                if (await _repo.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var error = new ErrorModel
            {
                ErrorTitle = "Något gick fel!",
                ErrorMessage = $"Fel vid updaterandet av kursen {course.CourseName}!"
            };

            return View("_Error", error);
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
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
            var courseToDelete = await _repo.FindByIdAsync(courseId);

            if (courseToDelete is null) return RedirectToAction(nameof(Index));

            if (await _repo.DeleteAsync(courseToDelete))
            {
                if (await _repo.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var error = new ErrorModel
            {
                ErrorTitle = "Fel vid raderandet!",
                ErrorMessage = $"Fel vid raderandet av kursen {courseToDelete.CourseName}!"
            };

            return View("_Error", error);

        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Fel vid raderandet!",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }
}
