using Microsoft.AspNetCore.Mvc;

namespace DTS_WebApp.Controllers;
public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
