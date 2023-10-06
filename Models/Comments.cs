using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.Models
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public int PostID { get; set; }
    }
}
