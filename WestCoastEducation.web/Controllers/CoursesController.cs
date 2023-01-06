using Microsoft.AspNetCore.Mvc;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.ViewModels;

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
        return View("Index", courses);
    }

    [Route("course/{courseName}")]
    public IActionResult Details(string courseName)
    {
        return View("course");
    }
}
