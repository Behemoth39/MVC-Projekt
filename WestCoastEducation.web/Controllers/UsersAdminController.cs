using Microsoft.AspNetCore.Mvc;
using WestCoastEducation.web.Interfaces;
using WestCoastEducation.web.Models;
using WestCoastEducation.web.ViewModels;

namespace WestCoastEducation.web.Controllers;

[Route("users/admin")]
public class UsersAdminController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersAdminController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var user = await _unitOfWork.UserRepository.ListAllAsync();
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
        var user = new UserPostViewModel();
        return View("Create", user);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(UserPostViewModel user)
    {
        try
        {
            if (!ModelState.IsValid) return View("Create", user);

            if (await _unitOfWork.UserRepository.FindByUserNameAsync(user.UserName) is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Något gick fel!",
                    ErrorMessage = $"Kursen {user.UserName} existerar redan"
                };
                return View("_Error", error);
            }

            var userToAdd = new UserModel
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Email = user.Email,
                Password = user.Password,
                TypeOfUser = user.TypeOfUser
            };

            if (await _unitOfWork.UserRepository.AddAsync(userToAdd))
            {
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var saveError = new ErrorModel
            {
                ErrorTitle = "Något gick fel!",
                ErrorMessage = $"Fel vid sparande av {user.UserName}!"
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

    [HttpGet("edit/{userId}")]
    public async Task<IActionResult> Edit(int userId)
    {
        try
        {
            var result = await _unitOfWork.UserRepository.FindByIdAsync(userId);

            if (result is null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Fel vid inläsning av id!",
                    ErrorMessage = $"Kursen med id {userId} existerar inte"
                };

                return View("_Error", error);
            }

            var userToUpdate = new UserUpdateViewModel
            {
                UserId = result.UserId,
                UserName = result.UserName,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Phone = result.Phone,
                Email = result.Email,
                Password = result.Password,
                TypeOfUser = result.TypeOfUser
            };

            return View("Edit", userToUpdate);
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

    [HttpPost("edit/{userId}")]
    public async Task<IActionResult> Edit(int userId, UserUpdateViewModel user)
    {
        try
        {
            if (!ModelState.IsValid) return View("Edit", user);

            var userToUpdate = await _unitOfWork.UserRepository.FindByIdAsync(userId);

            if (userToUpdate is null) return RedirectToAction(nameof(Index));

            userToUpdate.UserName = user.UserName;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Phone = user.Phone;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
            userToUpdate.TypeOfUser = user.TypeOfUser;

            if (await _unitOfWork.UserRepository.UpdateAsync(userToUpdate))
            {
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var error = new ErrorModel
            {
                ErrorTitle = "Något gick fel!",
                ErrorMessage = $"Fel vid updaterandet av kursen {user.UserName}!"
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

    [Route("delete/{userId}")]
    public async Task<IActionResult> Delete(int userId)
    {
        try
        {
            var userToDelete = await _unitOfWork.UserRepository.FindByIdAsync(userId);

            if (userToDelete is null) return RedirectToAction(nameof(Index));

            if (await _unitOfWork.UserRepository.DeleteAsync(userToDelete))
            {
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var error = new ErrorModel
            {
                ErrorTitle = "Fel vid raderandet!",
                ErrorMessage = $"Fel vid raderandet av kursen {userToDelete.UserName}!"
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
