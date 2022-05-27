using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly AppDBContext context;

        public PolicyService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<List<PolicySection>> GetPoliciesAsync()
        {
            return await context.Policies.Where(m=>m.IsDelete == false).ToListAsync();
        }

        public async Task<PolicySection> GetPolicyWithIdAsync(int policyId)
        {
            return await context.Policies.Where(m => m.Id == policyId && !m.IsDelete).FirstOrDefaultAsync();
        }
    }
}
