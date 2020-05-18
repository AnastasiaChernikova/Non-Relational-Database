using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Core.Entities;
using MVC.Interfaces;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class PostsController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly IArtistService _artistService;

        public PostsController(
            ILogger<HomeController> logger,
            IPostService postService,
            IArtistService ArtistService)
        {
            _logger = logger;
            _postService = postService;
            _artistService = ArtistService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("Posts", "Posts");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Posts()
        {
            var viewModel = await _postService.GetAllAsync();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult ReactionsClicked(string postId)
        {
            _postService.ReactionsClicked(User.Identity.Name, postId);
            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPost(string postText)
        {
            _postService.AddNewPostAsync(User.Identity.Name, postText);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddComment(string commentText, string postId)
        {
            _postService.AddNewCommentAsync(User.Identity.Name, commentText, postId);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
