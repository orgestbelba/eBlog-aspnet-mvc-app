using eBlog.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [Display(Name = "Category")]
        public PostCategory Category { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Post Time")]
        public DateTime PostTime { get; set; }

        //Navigation Properties
        public List<Comment> Comments { get; set; }
        
        //User
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
