using BackFinalProject.Models;
using BackFinalProject.Services;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Helpers;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BackFinalProject.Utilities.Helpers.Helper;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BackFinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMailService _mailService;


        public AccountController(RoleManager<IdentityRole> roleManager,
                                 UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 IMailService mailService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            AppUser appUser = new()
            {
                FullName = registerVM.FullName,
                UserName = registerVM.UserName,
                Email = registerVM.Email
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            await _userManager.AddToRoleAsync(appUser, UserRoles.Member.ToString());

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            var link = Url.Action(nameof(VerifyEmail), "Account", new { userId = appUser.Id, token = code }, Request.Scheme, Request.Host.ToString());

            string html = $"<a href={link}>Click Here</a>";

            string content = "Email for Register Confirmation";

            var mailRequest = new MailRequest
            {
                Subject = content,
                Body =  html,
                ToEmail = registerVM.Email
            };
            await _mailService.SendEmailAsync(mailRequest);

            return RedirectToAction(nameof(EmailVerification));
        }

        public IActionResult EmailVerification()
        {
            return View();
        }


        public async Task<IActionResult> VerifyEmail(string userId, string token)
        {
            if (userId == null || token is null) return BadRequest();
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user is null) return BadRequest();
            await _userManager.ConfirmEmailAsync(user, token);
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction(nameof(Login), "Account");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {   
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            AppUser user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);
            if(user is null)
            {
                user = await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);
            }

            if(user is null)
            {
                ModelState.AddModelError("", "Email or Password is wrong");
                return View(loginVM);
            }

            if (!user.IsActivated)
            {
                ModelState.AddModelError("", "Please Contact with Admin for Activation");
                return View(loginVM);
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

            if (!signInResult.Succeeded)
            {
                if (signInResult.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Please Confirm Your Account");
                    return View(loginVM);
                }
                ModelState.AddModelError("", "Email or Password is wrong");
                return View(loginVM);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPasswordVM)
        {
            if (!ModelState.IsValid) return View(forgetPasswordVM);
            var user = await _userManager.FindByEmailAsync(forgetPasswordVM.Email);
            if (user is null)
            {
                ModelState.AddModelError("", forgetPasswordVM.Email + "Could not found ");
                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action(nameof(ResetPassword),"Account", new { email = user.Email, token = code}, Request.Scheme, Request.Host.ToString());
            string html = $"<a href={link}>Click Here</a>";
            string content = "Email For Register Confirmation";
            var mailRequest = new MailRequest
            {
                Subject = content,
                Body = html,
                ToEmail = forgetPasswordVM.Email,
            };
            await _mailService.SendEmailAsync(mailRequest);
            return RedirectToAction(nameof(ForgetPasswordConfirm));
        }

        public IActionResult ForgetPasswordConfirm()
        {
            return View();
        }
        public IActionResult ResetPassword(string email, string token)
        {
            var resetPasswordModel = new ResetPasswordVM { Email = email, Token = token };
            return View(resetPasswordModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid) return View(resetPasswordVM);

            var user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);

            if (user is null) NotFound();

            IdentityResult result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
                return View(resetPasswordVM);
            }
            return RedirectToAction(nameof(Login));
        }


        public async Task CreateRole()
        {
            foreach (var role in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString()});
                }
            }
        }
    }
}
