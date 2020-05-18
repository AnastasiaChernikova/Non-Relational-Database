using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Interfaces;

namespace MVC.Controllers
{
    public class ArtistsController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly ILogger<ArtistsController> _logger;
        private readonly IPostService _postService;
        private readonly IArtistService _artistService;

        public ArtistsController(
            ILogger<ArtistsController> logger,
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
        public IActionResult Index()
        {
            return RedirectToAction("Artists", "Artists");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Artists()
        {
            var users = await _artistService.GetAllAsync();
            return View(users);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Follow(string userEmail)
        {
            ViewData["authorizedUser"] = User.Identity.Name;
            _artistService.Follow(User.Identity.Name, userEmail);
            return NoContent();
        }
        public IActionResult RemoveFriend(string userEmail)
        {
            ViewData["authorizedUser"] = User.Identity.Name;
            _artistService.RemoveFriend(User.Identity.Name, userEmail);
            return NoContent();
        }
    }
}
