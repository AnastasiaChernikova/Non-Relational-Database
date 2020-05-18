using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Core.Entities;
using MVC.Interfaces;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly ILogger<AccountController> _logger;
        private readonly IPostService _postService;
        private readonly IArtistService _artistService;

        public AccountController(
            ILogger<AccountController> logger,
            IPostService postService,
            IArtistService ArtistService
            )
        {
            _logger = logger;
            _postService = postService;
            _artistService = ArtistService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var authorizedUser = new ArtistViewModel();
            var profileModel = new PortfolioViewModel();
            try
            {
                authorizedUser = await _artistService.GetByEmailAsync(User.Identity.Name);
                profileModel = await _artistService.GetProfileModel(authorizedUser);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            profileModel.IsAuthorized = true;

            return View(profileModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ProfileByEmail(string authorEmail)
        {
            var authorizedUser = await _artistService.GetByEmailAsync(User.Identity.Name);

            var userModel = await _artistService.GetByEmailAsync(authorEmail);
            var profileModel = await _artistService.GetProfileModel(userModel);

            if (authorizedUser.Email == profileModel.Email)
            {
                profileModel.IsAuthorized = true;
            }
            return View("Profile", profileModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(PortfolioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userProfile = await _artistService.UpdateUserAsync(viewModel);
                return RedirectToAction("Profile", "Account");
            }
            ModelState.AddModelError("", "Auth failed");
            return NoContent();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isAuthorized = await _artistService
                    .CheckPasswordByEmailAsync(model.Email, model.Password);

                if (isAuthorized)
                {
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Auth failed");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isUserExists = await _artistService.IsUserExistsAsync(model.Email);
                if (!isUserExists)
                {
                    if (model.Password == model.ConfirmPassword)
                    {
                        var newUser = new ArtistViewModel()
                        {
                            Email = model.Email,
                            Password = model.Password,
                            Name = "New Artist",
                            Nickname = "Painter",
                            Avatar = "https://cdn3.iconfinder.com/data/icons/peoples-id-set/50/7-512.png",
                            Followers = new List<Followers>()
                        };
                        _artistService.InsertUserAsync(newUser);
                    }
                    return RedirectToAction("Profile", "Account");
                }
                else
                    ModelState.AddModelError("", "Auth failed");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}