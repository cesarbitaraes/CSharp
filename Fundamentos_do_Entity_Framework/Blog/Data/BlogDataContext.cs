using Blog.Data.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogDataContext : DbContext
{
    // Mapeamento criado para o uso de Data Annotations
    // public DbSet<Category> Categories { get; set; }
    // public DbSet<Post> Posts { get; set; }
    // // public DbSet<PostTag> PostTags { get; set; }
    // // public DbSet<Role> Roles { get; set; }
    // // public DbSet<Tag> Tags { get; set; }
    // public DbSet<User> Users { get; set; }
    // // public DbSet<UserRole> UserRoles { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PostWithTagsCount> PostWithTagsCounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=localhost,1433;Database=Blog;User ID=sa;Password=caab@1987;TrustServerCertificate=True");
        //options.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new PostMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.Entity<PostWithTagsCount>(x =>
        {
            x.ToSqlQuery(@"
                SELECT [Title] AS [Name],
                       SELECT COUNT([Id]) FROM [Tags] WHERE [PostId] = [Id]
                            AS [Count]
                FROM
                    [Posts]");
        });
    }
}