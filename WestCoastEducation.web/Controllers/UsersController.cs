using Microsoft.AspNetCore.Mvc;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.ViewModels;

namespace WestCoastEducation.web.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _unitOfWork.UserRepository.ListAllAsync();
        var model = users.Select(u => new UserListViewModel
        {
            UserId = u.UserId,
            UserName = u.UserName,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Phone = u.Phone,
            Email = u.Email,
            TypeOfUser = u.TypeOfUser
        }).ToList();
        return View("Index", model);
    }

    [Route("user/{userName}")] //används ej än
    public IActionResult Details(string userName)
    {
        return View("user");
    }
}
