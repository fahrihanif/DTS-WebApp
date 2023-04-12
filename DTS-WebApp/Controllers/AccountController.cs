using DTS_WebApp.Repository.Contracts;
using DTS_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DTS_WebApp.Controllers;
public class AccountController : Controller
{
    private readonly IAccountRepository _accountRepository;
    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    // GET - Register
    public IActionResult Register()
    {
        var gender = new List<SelectListItem>(){
            new SelectListItem{
                Text = "Male",
                Value = "0",
            },
            new SelectListItem{
                Text = "Female",
                Value = "1",
        }};

        ViewBag.Gender = gender;

        return View();
    }

    // POST - Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterVM registerVM)
    {
        var result = _accountRepository.Register(registerVM);
        if (result > 0) {
            return RedirectToAction("Login", "Account");
        }
        return View();
    }

    // GET - Login
    public IActionResult Login()
    {
        return View();
    }
}
