using E_Commerce.Models;
using E_Commerce.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;



        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() => View(new SignUpModel());

        [HttpPost]
        public async Task<IActionResult> Register(SignUpModel signUpModel)
        {
            
            var result = await _accountRepository.SignUp(signUpModel);
            if (result.Succeeded)
            {
                SignInModel sign = new SignInModel();
                sign.Email = signUpModel.Email;
                sign.Password = signUpModel.Password;
                await _accountRepository.Login(sign);
                return RedirectToAction("Index", "Movies");
                
            }
            return View(signUpModel);

            // return Unauthorized();
            //if (!ModelState.IsValid)
            //{ 
            //    return View(signUpModel); 
            //}

            // var user = await _userManager.FindByEmailAsync(signUpModel.EmailAddress);

            //if (user != null)
            //{
            //    TempData["Error"] = "This email address is already in use";
            //    return View(registerVM);
            //}

            //var newUser = new ApplicationUser()
            //{
            //    FullName = registerVM.FullName,
            //    Email = registerVM.EmailAddress,
            //    UserName = registerVM.EmailAddress
            //};
            //var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            //if (newUserResponse.Succeeded)
            //    await _userManager.AddToRoleAsync(newUser, UserRoles.User);


        }

        public IActionResult Login() => View(new SignInModel());

        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            var result = await _accountRepository.Login(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return View();
            }
           
            return RedirectToAction("Index", "Movies");

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
