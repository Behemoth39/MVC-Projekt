using Microsoft.AspNetCore.Mvc;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Controllers
{
    [Route("courses")]
    public class CoursesController : Controller
    {      
        public IActionResult Index()
        {
            var courses = new List<Course>{
                new Course{CourseName = "Development", CourseNumer ="2516", EnrollmentLimit ="30", CourseStart = DateTime.Today.AddDays(30), CourseEnd = DateTime.Today.AddMonths(12)},
                new Course{CourseName = "Technician", CourseNumer ="0158", EnrollmentLimit ="25", CourseStart = DateTime.Today.AddDays(20), CourseEnd = DateTime.Today.AddMonths(18)},
                new Course{CourseName = "Electrician", CourseNumer ="223", EnrollmentLimit ="30", CourseStart = DateTime.Today.AddDays(40), CourseEnd = DateTime.Today.AddMonths(24)},
                new Course{CourseName = "Robotics", CourseNumer ="7089", EnrollmentLimit ="20", CourseStart = DateTime.Today.AddDays(15), CourseEnd = DateTime.Today.AddMonths(8)}
            };  

            return View("Index", courses);
        }
    }
}