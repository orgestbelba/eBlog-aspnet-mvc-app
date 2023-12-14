using eBlog.Data;
using eBlog.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBlog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Identity;
using eBlog.ViewModels;

namespace eBlog.Controllers
{
    public class PostsController : Controller
    {

        private readonly IPostService _service;  // injecting the Post Service to the controller

        private readonly UserManager<User> _userManager;

        [Obsolete]
        private readonly IHostingEnvironment Environment;

        [Obsolete]
        public PostsController(IPostService service,
            IHostingEnvironment _environment,
            UserManager<User> userManager)
        {
            _service = service;
            Environment = _environment;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();

            return View(data);
        }

        //GET: SinglePost/id
        public async Task<IActionResult> SinglePost(int id)
        {
            var data = await _service.GetByID(id);

            if (data == null) return View("Empty");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SinglePost(SinglePostViewModel newComment)
        {
            
            if (!ModelState.IsValid)
                return View();

            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);

                Comment comment = new Comment
                {
                    TheComment = newComment.Comment.TheComment,
                    CommentTime = DateTime.Now,
                    PostID = newComment.CurrentPost.PostID,
                    UserId = currentUser.Id,
                };

                await _service.AddComment(comment);
                return RedirectToAction("SinglePost", "Posts", new { id = newComment.CurrentPost.PostID });
            }
            else
            {
                return View("LogInFirst");
            }

        }


        //GET: Search/searchString 
        public async Task<IActionResult> Search(string searchString)
        {
            var data = await _service.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                string filter = searchString.ToLower(); //Making the search not Case Sensitive
                var matches = data.Where(p => p.Title.ToLower().Contains(filter) || p.Text.ToLower().Contains(filter));
                return View("Index", matches);
            }

            return View("Index", data);
        }

        //GET: GetByCategory/category
        public async Task<IActionResult> GetByCategory(string category)
        {
            var data = await _service.GetAll();

            var matches = data.Where(p => p.Category.ToString() == category);

            return View("Index", matches);

        }

        public IActionResult CreatePost()
        {

            if (User.Identity.IsAuthenticated)
                return View();
            else
                return View("LogInFirst");

        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> CreatePost(Post newPost, IFormFile postedFiles)
        {
            if (!ModelState.IsValid)
                return View();

            string path = Path.Combine(this.Environment.WebRootPath, "images");
            string fileName = Path.GetFileName(postedFiles.FileName);

            using (FileStream stream = new(Path.Combine(path, fileName), FileMode.Create))
                postedFiles.CopyTo(stream);

            newPost.ImagePath = Path.Combine("~/images/", fileName);

            var currentUser = await _userManager.GetUserAsync(User);
            newPost.UserId = currentUser.Id;

            await _service.AddPost(newPost);

            return RedirectToAction("Index", "Posts");
            
        }
    }
}
