using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
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
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Post> _postRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<User> userRepository, IRepository<Test> testRepository, IRepository<Question> questionRepository, IRepository<Post> postRepository)
        {
          
            _logger = logger;
            _userRepository = userRepository;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _postRepository = postRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var lastPosts = _postRepository.GetAll();

            return View(lastPosts);
        }



        [Authorize]
        [HttpGet("CreateTest")]
        public IActionResult CreateTest(int postId)
        {

            #region BLL_Katmani

            var selectedPost = _postRepository.Query(w => w.Id == postId).First();


            var postViewModel = new TestViewModel()
            {
                PostId = selectedPost.Id,
                PostContent = selectedPost.Content,
                PostTitle = selectedPost.Title,
            };


            #endregion


            return View(postViewModel);
        }



        [Authorize]
        [HttpPost("CreateTest")]
        public IActionResult CreateTest(TestViewModel testViewModel)
        {
            if (!ModelState.IsValid)
                return View(testViewModel);

            #region BLL_Katmani
            {


                // create and  insert test
                var test = new Test()
                {
                    PostId = 11,
                    CreatedDate = DateTime.UtcNow,

                };

                _testRepository.Add(test);

                //create and insert test questions
                var questionEntities = new List<Question>();

                foreach (var questionModel in testViewModel.Questions)
                {
                    var question = new Question()
                    {
                        TestId = test.Id,
                        CreatedDate = DateTime.UtcNow,
                        Inquiry = questionModel.Inquiry,
                        CorrectOption = questionModel.CorrectOption,
                        OptionA = questionModel.OptionA,
                        OptionB = questionModel.OptionB,
                        OptionC = questionModel.OptionC,
                        OptionD = questionModel.OptionD,
                    };

                    questionEntities.Add(question);

                }

                _questionRepository.AddRaange(questionEntities);

            }
            #endregion


            return RedirectToAction("Index");
        }

        [HttpGet("SignUp")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("SignUp")]
        public IActionResult Register(RegisterViewModel registerModel)
        {

            if (!ModelState.IsValid)
                return View();


            #region BLL_Katmani

            var user = new User()
            {
                CreatedDate = System.DateTime.UtcNow,
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                UserName = registerModel.UserName,
                Password = registerModel.Passowrd
            };

            _userRepository.Add(user);
            #endregion

            return RedirectToAction("Index");
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
            {

                var user = _userRepository.Query(w => w.UserName == loginModel.UserName).FirstOrDefault();

                if (user == null)
                {
                    TempData["UserCredentialErros"] = "UserName or password is wrong";
                    return View("Login");
                }

                if (user.Password != loginModel.Password)
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

                    return RedirectToAction("Index");

                }

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
