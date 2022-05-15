using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ISettingService settingService;

        public QuestionController(ISettingService settingService)
        {
            this.settingService = settingService;
        }
        public IActionResult Index()
        {
            QuestionVM questionVM = new()
            {
                Settings = settingService.GetSetting()
            };
            return View(questionVM);
        }
    }
}
