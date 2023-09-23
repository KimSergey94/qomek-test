using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BlogAPI.Data
{
    public class BlogAPIContext : DbContext
    {
        public BlogAPIContext(DbContextOptions<BlogAPIContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}