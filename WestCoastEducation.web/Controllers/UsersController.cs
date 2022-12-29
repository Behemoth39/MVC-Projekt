using Microsoft.AspNetCore.Mvc;

namespace WestCoastEducation.web.Controllers;

[Route("users")]
public class UsersController : Controller
{        
    public IActionResult Index()
    {
        return View("Index");
    }

}
