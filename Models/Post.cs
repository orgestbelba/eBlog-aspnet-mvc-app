using eBlog.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public PostCategory Category { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }

        //Relationships
        public List<Comments> Comments { get; set; }
    }
}
