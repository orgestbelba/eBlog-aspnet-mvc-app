using eBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.Data.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetByID(int id);
        Task AddPost(Post post);
        Task<Post> Update(int id, Post newPost);
        Task Delete(int id);
    }
}
