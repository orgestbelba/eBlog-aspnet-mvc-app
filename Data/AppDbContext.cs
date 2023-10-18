using eBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace eBlog.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void onmodelcreating(modelbuilder modelbuilder)
        //{
        //    modelbuilder.entity<post>()
        //        .hasone(p => p.user)
        //        .withmany(u => u.posts)
        //        .hasforeignkey(p => p.userid);

        //    modelbuilder.entity<comment>()
        //        .hasone(c => c.user)
        //        .withmany(u => u.comments)
        //        .hasforeignkey(c => c.userid);

        //    modelbuilder.entity<comment>()
        //        .hasone(c => c.post)
        //        .withmany(p => p.comments)
        //        .hasforeignkey(c => c.postid);
        //    base.onmodelcreating(modelbuilder);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
