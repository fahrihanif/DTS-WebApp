using DTS_WebApp.Repository.Contracts;
using DTS_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DTS_WebApp.Controllers;
public class AccountController : Controller
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEmployeeRepository _employeeRepository;
    public AccountController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository)
    {
        _accountRepository = accountRepository;
        _employeeRepository = employeeRepository;
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

    // POST - Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginVM loginVM)
    {
        var result = _accountRepository.Login(loginVM);
        if (!result) {
            ModelState.AddModelError(string.Empty, "Email or Password is Incorrect!");
            return View();
        }

        var getFullName = _employeeRepository.GetFullName(loginVM.Email);
        HttpContext.Session.SetString("FullName", getFullName);

        return RedirectToAction("Index", "Home");
    }
}
