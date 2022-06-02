using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class PolicyController : Controller
    {
        private readonly AppDBContext context;
        private readonly IPolicyService policyService;
        private readonly IWebHostEnvironment environment;

        public PolicyController(AppDBContext context,
                                IPolicyService policyService,
                                IWebHostEnvironment environment)
        {
            this.context = context;
            this.policyService = policyService;
            this.environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await policyService.GetPoliciesAsync());
        }
        
        public IActionResult Create(int policyId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int policyId, PolicySection policy)
        {
            if (!ModelState.IsValid) return View(policy);
            if(policy.Name.Length > 100)
            {
                ModelState.AddModelError(nameof(policy.Name), "Name should be less than 100 characters");
                return View(policy);
            }
            if(policy.Detail != null)
            {
                if (policy.Detail.Length > 700)
                {
                    ModelState.AddModelError(nameof(policy.Detail), "Detail should be less than 100 characters");
                    return View(policy);
                }
            }
            await context.Policies.AddAsync(policy);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int policyId)
        {
            PolicySection policy = await policyService.GetPolicyWithIdAsync(policyId);
            if (policy is null) NotFound();
            return View(policy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int policyId, PolicySection policy)
        {
            if (!ModelState.IsValid) return View(policy);
            if (policy.Name.Length > 100)
            {
                ModelState.AddModelError(nameof(policy.Name), "Name should be less than 100 characters");
                return View(policy);
            }
            if (policy.Detail != null)
            {
                if (policy.Detail.Length > 700)
                {
                    ModelState.AddModelError(nameof(policy.Detail), "Detail should be less than 100 characters");
                    return View(policy);
                }
            }
            PolicySection dbPolicy = await policyService.GetPolicyWithIdAsync(policyId);
            if (!ModelState.IsValid) return View(policy);
            dbPolicy.Name = policy.Name;
            dbPolicy.Detail = policy.Detail;
            context.Policies.Update(dbPolicy);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int policyId)
        {
            PolicySection policy = await policyService.GetPolicyWithIdAsync(policyId);
            if (policy is null) NotFound();
            policy.IsDelete = true;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int policyId)
        {
            PolicySection policy = await policyService.GetPolicyWithIdAsync(policyId);
            if (policy is null) NotFound();
            return View(policy);
        }
    }
}
