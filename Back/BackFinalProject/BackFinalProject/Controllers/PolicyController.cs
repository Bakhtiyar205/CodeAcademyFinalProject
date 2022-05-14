using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IPolicyService policyService;

        public PolicyController(IPolicyService policyService)
        {
            this.policyService = policyService;
        }

        public async Task<IActionResult> Index()
        {
            PolicyVM policyVM = new()
            {
                Policies = await policyService.GetPoliciesAsync()
            };
            return View(policyVM);
        }
    }
}
