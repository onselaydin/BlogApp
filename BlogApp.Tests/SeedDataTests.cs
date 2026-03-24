using BlogApp.Data;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Tests;

public class SeedDataIntegrationTests
{
    private BlogAppContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<BlogAppContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var context = new BlogAppContext(options);
        context.Database.EnsureCreated(); // This applies the seed data
        return context;
    }

    [Fact]
    public async Task SeedData_ShouldContainInitialPosts()
    {
        // Arrange
        using var context = GetInMemoryContext();

        // Act
        var posts = await context.Posts.ToListAsync();

        // Assert
        Assert.Equal(3, posts.Count);
        Assert.Contains(posts, p => p.Title == "Welcome to the Blog");
        Assert.Contains(posts, p => p.Title == "Second Post");
        Assert.Contains(posts, p => p.Title == "Third Post");
    }

    [Fact]
    public async Task SeedData_ShouldHaveCorrectAuthors()
    {
        // Arrange
        using var context = GetInMemoryContext();

        // Act
        var posts = await context.Posts.ToListAsync();

        // Assert
        var adminPost = posts.First(p => p.Author == "Admin");
        Assert.Equal("Welcome to the Blog", adminPost.Title);

        var editorPost = posts.First(p => p.Author == "Editor");
        Assert.Equal("Second Post", editorPost.Title);

        var writerPost = posts.First(p => p.Author == "Writer");
        Assert.Equal("Third Post", writerPost.Title);
    }
}