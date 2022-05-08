using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
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

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet("SignUp")]
        public IActionResult Register(RegisterViewModel registerModel)
        {




            return View();
        }


        [HttpPost("SignUp")]
        public IActionResult RegisterPost(RegisterViewModel registerModel)
        {


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
        public IActionResult Login(LoginViewModel loginModel)
        {
            return View();
        }

        [HttpPost("SignIn")]
        public IActionResult LoginPost(LoginViewModel loginModel)
        {
            return View();
        }


    }
}
