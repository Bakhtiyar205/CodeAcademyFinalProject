using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ISettingService settingService;
        private readonly IProductService productService;

        public QuestionController(ISettingService settingService,
                                  IProductService productService)
        {
            this.settingService = settingService;
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            QuestionVM questionVM = new()
            {
                Settings = settingService.GetSetting(),
                Products = await productService.GetProductsAsync()
            };
            return View(questionVM);
        }
    }
}
