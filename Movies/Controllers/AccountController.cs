using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Movies.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var claims = new List<Claim>
                //{
                //    new Claim("Demo", "Value")
                //};
                //var claimIdentity = new ClaimsIdentity(claims, "Cookie");
                //var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                //await HttpContext.SignInAsync("Cookie", claimPrincipal);
                //return Redirect(model.ReturnUrl);
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Пользователь не найден!");
                    return View(model);
                }
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
               
                if (result.Succeeded)
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "отказано в доступе");
                }
                
                
            }
            return View(model);
        }

        [Authorize(Policy = "Admin")]
        public  string Admin()
        {
            return "admin panel";
        }


        [Authorize(Policy = "Manager")]
        public string Manager()
        {
            return "Manager panel";
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Movies/Index");
        }
    }
}
