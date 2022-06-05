
using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ISettingService settingService;
        private readonly IBrendService brendService;
        private readonly IBlogService blogService;
        private readonly ISubscriptionService subscriptionService;

        public HomeController(ICategoryService categoryService,
                                ISettingService settingService,
                                IBrendService brendService,
                                IBlogService blogService,
                                ISubscriptionService subscriptionService)
        {
            this.categoryService = categoryService;
            this.settingService = settingService;
            this.brendService = brendService;
            this.blogService = blogService;
            this.subscriptionService = subscriptionService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new()
            {
                Categories = await categoryService.GetCategoriesAsync(),
                Setting = settingService.GetSetting(),
                Brends = await brendService.GetBrendsAsync(),
                Blogs = await blogService.GetBlogsAsync()
            };
            return View(homeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email,string name, bool policy)
        {
            if(email.Length > 100 && name.Length > 100)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            if (policy == false)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            if ((await subscriptionService.Subscription(email, name))is null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
