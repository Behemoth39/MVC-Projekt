using Microsoft.AspNetCore.Mvc;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.ViewModels;

namespace WestCoastEducation.web.Controllers;

[Route("users/admin")]
public class UsersAdminController : Controller
{
    private readonly IUserRepository _repo;
    public UsersAdminController(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _repo.ListAllAsync();
        var model = user.Select(u => new UserListViewModel
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

    [HttpGet("create")]
    public IActionResult Create()
    {
        var user = new UserPostViewModel();
        return View("Create", user);
    }
}
