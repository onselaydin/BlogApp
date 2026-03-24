using BlogApp.Data;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Tests;

public class PostCrudTests
{
    private BlogAppContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<BlogAppContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new BlogAppContext(options);
    }

    [Fact]
    public async Task CreatePost_ShouldAddPostToDatabase()
    {
        // Arrange
        using var context = GetInMemoryContext();
        var post = new Post { Title = "Test Post", Content = "Test Content", Author = "Test Author" };

        // Act
        context.Posts.Add(post);
        await context.SaveChangesAsync();

        // Assert
        var savedPost = await context.Posts.FirstOrDefaultAsync(p => p.Title == "Test Post");
        Assert.NotNull(savedPost);
        Assert.Equal("Test Post", savedPost.Title);
        Assert.Equal("Test Content", savedPost.Content);
        Assert.Equal("Test Author", savedPost.Author);
    }

    [Fact]
    public async Task ReadPost_ShouldRetrievePostFromDatabase()
    {
        // Arrange
        using var context = GetInMemoryContext();
        var post = new Post { Title = "Read Test", Content = "Read Content", Author = "Read Author" };
        context.Posts.Add(post);
        await context.SaveChangesAsync();

        // Act
        var retrievedPost = await context.Posts.FindAsync(post.Id);

        // Assert
        Assert.NotNull(retrievedPost);
        Assert.Equal(post.Id, retrievedPost.Id);
        Assert.Equal("Read Test", retrievedPost.Title);
    }

    [Fact]
    public async Task UpdatePost_ShouldModifyPostInDatabase()
    {
        // Arrange
        using var context = GetInMemoryContext();
        var post = new Post { Title = "Update Test", Content = "Update Content", Author = "Update Author" };
        context.Posts.Add(post);
        await context.SaveChangesAsync();

        // Act
        post.Title = "Updated Title";
        context.Posts.Update(post);
        await context.SaveChangesAsync();

        // Assert
        var updatedPost = await context.Posts.FindAsync(post.Id);
        Assert.NotNull(updatedPost);
        Assert.Equal("Updated Title", updatedPost.Title);
    }

    [Fact]
    public async Task DeletePost_ShouldRemovePostFromDatabase()
    {
        // Arrange
        using var context = GetInMemoryContext();
        var post = new Post { Title = "Delete Test", Content = "Delete Content", Author = "Delete Author" };
        context.Posts.Add(post);
        await context.SaveChangesAsync();

        // Act
        context.Posts.Remove(post);
        await context.SaveChangesAsync();

        // Assert
        var deletedPost = await context.Posts.FindAsync(post.Id);
        Assert.Null(deletedPost);
    }
}
