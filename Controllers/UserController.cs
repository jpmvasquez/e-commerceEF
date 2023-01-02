using E_Commerce_Project.Data;
using E_Commerce_Project.Data.ViewModels;
using E_Commerce_Project.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }


        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Les données de connexion sont fausses";
                return View(loginVM);
            }

            TempData["Error"] = "Les données de connexion sont fausses";
            return View(loginVM);
        }


        public IActionResult CreateAccount() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> CreateAccount(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) 
                return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["EmailError"] = "L'adresse email existe déjà.";
                return View(registerVM);
            }

            Address address = registerVM.address;
            _context.Address.Add(registerVM.address);
            var newUser = new ApplicationUser()
            {
                firstName = registerVM.firstName,
                lastName = registerVM.lastName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,
                addressId = address.id,
                civility = registerVM.civility
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            else
            {
                TempData["PwdError"] = "Le mdp n'est pas valide";
                return View(registerVM);
            }

            return View("RegistrationComplete");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
