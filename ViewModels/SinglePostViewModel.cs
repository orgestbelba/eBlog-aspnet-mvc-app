using eBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.ViewModels
{
    public class SinglePostViewModel
    {
        public Post CurrentPost { get; set; }
        public List<Post> RelatedPosts { get; set; }
    }
}
