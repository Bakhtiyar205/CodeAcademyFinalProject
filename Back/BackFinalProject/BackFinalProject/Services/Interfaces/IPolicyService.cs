using BackFinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IPolicyService
    {
        Task<List<PolicySection>> GetPoliciesAsync();
        Task<PolicySection> GetPolicyWithIdAsync(int policyId);
    }
}
