using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestApp.DAL.Repositories.Abstract;
using TestApp.Domains.Domains;
using TestApp.Domains.ViewModel;

namespace TestApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepository<User> _userRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<User> userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }



        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet("SignUp")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("SignUp")]
        public IActionResult Register(RegisterViewModel registerModel)
        {

            if(!ModelState.IsValid)
                return View();


            #region BLL_Katmani

            var user = new User()   
            {
                CreatedDate = System.DateTime.UtcNow,
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                UserName = registerModel.LastName,
                Password = registerModel.Passowrd
            };

            _userRepository.Add(user);
            #endregion

            return RedirectToAction("Index") ;
        }


        [HttpGet("SignIn")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {


            if (!ModelState.IsValid)
                return View();



            #region BLL_Katmani

            var user = _userRepository.Query( w=> w.UserName  ==  loginModel.UserName).FirstOrDefault();

            if(user == null) 
            {
                TempData["UserCredentialErros"] = "UserName or password is wrong";
                return View("Login");
            }

            if(user.Password != loginModel.Password)
            {
                TempData["UserCredentialErros"] = "UserName or password is wrong";
                return View("Login");
            }

            if (user.Password == loginModel.Password)
            {
                // Login

                var claims = new List<Claim>();
                claims.Add(new Claim("username", user.UserName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
                claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
                var clamisIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(clamisIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Privacy");

            }



            #endregion


            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();

            return Redirect("/");
        }


    }
}
