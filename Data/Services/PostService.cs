using eBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.Data.Services
{
    public class PostService : IPostService
    {

        private readonly AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            var data = await _context.Posts
                .Include(p => p.User) //Including the Users navigation property for posts
                .Include(p => p.Comments) //Including the Comments navigation property for posts
                .ToListAsync();

            return data;
        }

        public async Task<Post> GetByID(int id)
        {
            var data = await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User) //Including the User navigation property for the Comments
                .FirstOrDefaultAsync(p => p.PostID == id);

            return data;
        }

        Task<Post> IPostService.Update(int id, Post newPost)
        {
            throw new NotImplementedException();
        }
    }
}
