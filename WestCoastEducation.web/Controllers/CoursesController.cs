using Microsoft.AspNetCore.Mvc;

namespace WestCoastEducation.web.Controllers
{
    [Route("courses")]
    public class CoursesController : Controller
    {      
        public IActionResult Index()
        {
            ViewBag.Courses = new List<string>{
                "Web Development",
                "Mechanical",
                "Technician",
                "Electrician"
            };
            return View("Index");
        }
    }
}