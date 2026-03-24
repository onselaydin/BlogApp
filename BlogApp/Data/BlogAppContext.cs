using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class BlogAppContext : DbContext
    {
        public BlogAppContext(DbContextOptions<BlogAppContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Welcome to the Blog",
                    Content = "This is the first post on our blog. Welcome!",
                    Author = "Admin",
                    CreatedDate = new DateTime(2023, 1, 1)
                },
                new Post
                {
                    Id = 2,
                    Title = "Second Post",
                    Content = "This is the second post. Hope you enjoy reading.",
                    Author = "Editor",
                    CreatedDate = new DateTime(2023, 1, 2)
                },
                new Post
                {
                    Id = 3,
                    Title = "Third Post",
                    Content = "Another interesting post for our readers.",
                    Author = "Writer",
                    CreatedDate = new DateTime(2023, 1, 3)
                }
            );
        }
    }
}