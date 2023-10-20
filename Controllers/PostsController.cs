using eBlog.Data;
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
        // injecting the AppDbContext to the controller

        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await _context.Posts.ToListAsync();
            return View(data);
        }

    }
}
