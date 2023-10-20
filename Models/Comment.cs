using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.Models
{
    public class Comment
    { 
        [Key]
        public int CommentID { get; set; }
        public string TheComment { get; set; }
        public DateTime CommentTime { get; set; }

        //Relationships

        //User
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        //Post
        [ForeignKey("PostID")]
        public int PostID { get; set; }
        public virtual Post Post { get; set; }
    }
}
