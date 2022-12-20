using Microsoft.AspNetCore.Mvc;

namespace WestCoastEducation.web.Controllers
{
    [Route("[controller]")]
    public class CoursesController : Controller
    {      
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}