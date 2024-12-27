using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
 

namespace MyApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.SignInManager = signInManager;
            this.UserManager = userManager;
        }

        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)  //the model we have defined in the Acccountcontroller.cs file
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Email, // Username typically defaults to the email
                    Email = model.Email     // Set the email address

                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("login");
        }
         
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegisterViewModel model)
        {
            if (ModelState.IsValid)  //the model we have defined in the Acccountcontroller.cs file
            {

                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                     
                    return RedirectToAction("Index", "Home");
                }
                // Add error message for failed login
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");

            }
            return View("Login", model);
        }
    }
}
