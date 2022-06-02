using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class BrendController : Controller
    {
        private readonly IBrendService brendService;
        private readonly IProductService productService;

        public BrendController(IBrendService brendService,
                               IProductService productService)
        {
            this.brendService = brendService;
            this.productService = productService;
        }
        public async Task<IActionResult> BrendDetail(int brendId)
        {
            BrendVM brendVM = new()
            {
                Brend = await brendService.GetBrendWithIdAsync(brendId),
                Products = await productService.GetProductsAsync()
            };
            return View(brendVM);
        }

        public async Task<IActionResult> Index()
        {
            BrendsVM brendsVM = new()
            {
                Brends = await brendService.GetBrendsAsync(),
                Products = await productService.GetProductsAsync()
            };
            return View(brendsVM);
        }
    }
}
