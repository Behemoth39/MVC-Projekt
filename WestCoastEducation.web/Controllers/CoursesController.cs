using Microsoft.AspNetCore.Mvc;
using WestCoastEducation.web.Models;

namespace WestCoastEducation.web.Controllers
{
    [Route("courses")]
    public class CoursesController : Controller
    {      
        public IActionResult Index()
        {        

            return View("Index");
        }

        [Route("course/{courseName}")]
        public IActionResult Details()
        {             
            return View("course");
        }
    }
}