using Microsoft.AspNetCore.Mvc;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WestCoastEducation.web.Controllers;

[Route("courses")]
public class CoursesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CoursesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var courses = await _unitOfWork.CourseRepository.ListAllAsync();
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

    [Route("course/{courseId}")] //används ej än
    [Authorize()]
    public async Task<IActionResult> Details(int courseId)
    {
        var course = await _unitOfWork.CourseRepository.FindByIdAsync(courseId);

        if (course is not null)
        {
            var model = new CourseViewModel
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseNumber = course.CourseNumber,
                CourseTitle = course.CourseTitle,
                CourseStart = course.CourseStart,
                CourseLenght = course.CourseLenght
            };
        };
        return View("course", course);
    }
}
