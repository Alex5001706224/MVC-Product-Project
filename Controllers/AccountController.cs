using Assignment_12_1.Models;
using Assignment_12_1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Assignment_12_1.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                Assignment_12_1.Models.User newuser = new User()
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.PhoneNumber.ToString()

                };
                var result = await userManager.CreateAsync(newuser, registerViewModel.Password);
                if(result.Succeeded)
                {
                    //if(newuser.UserName == "Admin")
                    //{
                    //    await userManager.AddToRoleAsync(newuser, "Admin");
                    //    await userManager.AddToRoleAsync(newuser, "Eployee");
                    //}
                    //else
                    //{
                    //    await userManager.AddToRoleAsync(newuser, "Employee");
                    //}
                    return RedirectToAction("Login", "Account");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
