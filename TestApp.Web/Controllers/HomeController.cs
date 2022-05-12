using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
                        CorrectOption = (int)Enum.Parse(typeof(OptionsOfQuestion), questionModel.CorrectOption),
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


        [Authorize]
        [HttpGet("Tests")]
        public IActionResult ExistingTests()
        {
            var testViewModelList = new List<TestViewModel>();

            #region BLL_Katmani
            {
                //Get all created tests


                var existinTests = _testRepository.GetAllWithIncluding("Post", "Questions");

                foreach (var test in existinTests)
                {

                    var testViewModel = PrepareTestViewModel(test);

                    testViewModelList.Add(testViewModel);
                }

            }
            #endregion


            return View(testViewModelList);
        }


        [Authorize]
        [HttpGet("StartTest")]
        public IActionResult StartTest(int testId)
        {
            var testViewModel = new TestViewModel();

            #region BLL_Katmani
            {


                var willStartTest = _testRepository.QueryWithInclude(test => test.Id == testId, null, "Post", "Questions").FirstOrDefault();


                testViewModel = PrepareTestViewModel(willStartTest);
            }
            #endregion


            return View(testViewModel);
        }


        [Authorize]
        [HttpGet("DeleteTest")]
        public IActionResult DeleteTest(int testId)
        {
            var testViewModel = new TestViewModel();

            #region BLL_Katmani
            {
                var willDelete = _testRepository.QueryWithInclude(test => test.Id == testId, null, "Questions").FirstOrDefault();

                _testRepository.Delete(willDelete);


            }
            #endregion


            return RedirectToAction("ExistingTests");
        }



        [Authorize]
        [HttpPost("TestResult")]
        public IActionResult TestResult(Dictionary<int, string> selectedAnswers, int testId)
        {

            var response = new List<TestResultViewModel>();

            #region BLL_Katmani
            {

                var questions = _questionRepository.Query(q => q.TestId == testId).ToList();

                foreach (var questionWithAnswer in selectedAnswers)
                {
                    var question = questions.Where(w => w.Id == questionWithAnswer.Key).FirstOrDefault();

                    // secilen cevabın int karsılıgını buluyorum...
                    var selectedOptionId = (int)Enum.Parse(typeof(OptionsOfQuestion), questionWithAnswer.Value);


                    if (selectedOptionId == question.CorrectOption)
                    {
                        var lisItem = new TestResultViewModel
                        {
                            QuestionId = question.Id,
                            IsCorrect = true,
                            CorrectOption = ((OptionsOfQuestion)question.CorrectOption).ToString()
                        };

                        response.Add(lisItem);
                    }
                    else
                    {

                        var lisItem = new TestResultViewModel
                        {
                            QuestionId = question.Id,
                            IsCorrect = false,
                            CorrectOption = ((OptionsOfQuestion)question.CorrectOption).ToString()
                        };

                        response.Add(lisItem);

                    }


                }


            }
            #endregion


            return Json(response);
        }

        private TestViewModel PrepareTestViewModel(Test testEntity)
        {

            var testViewModel = new TestViewModel()
            {
                Id = testEntity.Id,
                PostContent = testEntity.Post.Content,
                PostId = testEntity.PostId,
                PostTitle = testEntity.Post.Title,
                Questions = PrepareQuestionsViewModel(testEntity.Questions),
                CreatedDate = testEntity.CreatedDate

            };

            return testViewModel;
        }

        private List<QuestionTestViewModel> PrepareQuestionsViewModel(ICollection<Question> questionsEntities)
        {

            var testQuestions = new List<QuestionTestViewModel>();


            foreach (var question in questionsEntities)
            {

                var testQuestion = new QuestionTestViewModel()
                {
                    Id = question.Id,
                    CorrectOption = ((OptionsOfQuestion)question.CorrectOption).ToString(),
                    Inquiry = question.Inquiry,
                    OptionA = $"A) {question.OptionA}",
                    OptionB = $"B) {question.OptionB}",
                    OptionC = $"C) {question.OptionC}",
                    OptionD = $"D) {question.OptionD}",
                };

                testQuestions.Add(testQuestion);

            }

            return testQuestions;
        }

    }
}
