using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevTest.Models;
using DevTest.Services;
using DevTest.Shared;
using DevTest.Interfaces;
using DevTest.Models.Response;

namespace DevTest.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly IUserService _userService; 

    public LoginController(ILogger<LoginController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService; 
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult RegisterError()
    {
        return View();
    }

    public IActionResult RegisterSuccess()
    {
        return View();
    }

    public IActionResult SubmitLogin()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SubmitLogin(string inputEmail, string inputPassword)
    {
        if (!String.IsNullOrEmpty(inputEmail) && !String.IsNullOrEmpty(inputPassword))
        {
            var userResponse = await _userService.Login(inputEmail, inputPassword);

            if (userResponse != null)
            {
                return RedirectToAction("Index", "Home"); 
            }
        }

        return View("RegisterError");
    }

    [HttpPost]
    public async Task<IActionResult> SubmitFormAsync(string inputEmail, string inputPassword, string inputPasswordConfirmation)
    {
        if (!String.IsNullOrEmpty(inputEmail) && (inputPassword == inputPasswordConfirmation)){
            var hash = SharedFunctions.Base64Encode(inputPassword);
            var userResponse = await _userService.RegisterUser(inputEmail, hash);

            if(userResponse != null)
            {
                    return View("RegisterSuccess");
            }
        }

        return View("RegisterError");
    }

    public ActionResult SubmitForm()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

