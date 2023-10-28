using eBlog.Data;
using eBlog.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.Controllers
{
    public class PostsController : Controller
    {

        private readonly IPostService _service;         // injecting the Post Service to the controller

        public PostsController(IPostService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();

            return View(data);
        }

        public async Task<IActionResult> SinglePost(int id)
        {
            var data = await _service.GetByID(id);

            if (data == null) return View("Empty");

            return View(data);
        }
    }
}
