using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Friendship> Friendships { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Hashtag> Hashtags { get; set; }
    public DbSet<PostHashtag> PostHashtags { get; set; }
    public DbSet<PostReport> PostReports { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Many-to-Many
        builder.Entity<PostHashtag>()
            .HasKey(x => new { x.PostId, x.HashtagId });

        builder.Entity<Post>()
            .Property(x => x.Content)
            .HasMaxLength(2000);

        builder.Entity<Comment>()
            .Property(x => x.Content)
            .HasMaxLength(500);

        builder.Entity<Story>()
            .Property(x => x.ImageUrl)
            .HasMaxLength(1000);

        builder.Entity<Notification>()
            .Property(x => x.Content)
            .HasMaxLength(500);

        builder.Entity<Friendship>()
            .Property(x => x.Status)
            .HasMaxLength(20)
            .HasDefaultValue("Pending");

        builder.Entity<PostReport>()
            .Property(x => x.Reason)
            .HasMaxLength(500);

        builder.Entity<Hashtag>()
            .Property(x => x.Name)
            .HasMaxLength(100);

        builder.Entity<Hashtag>()
            .HasIndex(x => x.Name)
            .IsUnique();

        // Friendship (self join)
        builder.Entity<Friendship>()
            .HasOne(f => f.Sender)
            .WithMany()
            .HasForeignKey(f => f.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Friendship>()
            .HasOne(f => f.Receiver)
            .WithMany()
            .HasForeignKey(f => f.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        // Like unique
        builder.Entity<Like>()
            .HasIndex(l => new { l.UserId, l.PostId })
            .IsUnique();

        // Report unique
        builder.Entity<PostReport>()
            .HasIndex(r => new { r.UserId, r.PostId })
            .IsUnique();

        // Notification default
        builder.Entity<Notification>()
            .Property(n => n.IsRead)
            .HasDefaultValue(false);

        builder.Entity<Post>()
            .Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Entity<Post>()
            .HasIndex(p => p.CreatedAt);

        builder.Entity<Comment>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Entity<Comment>()
            .HasIndex(c => c.CreatedAt);

        builder.Entity<Story>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Entity<Story>()
            .HasIndex(s => s.ExpiredAt);

        // 🔥 FIX CASCADE 

        // Comment
        builder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Restrict);

        // Like
        builder.Entity<Like>()
            .HasOne(l => l.Post)
            .WithMany(p => p.Likes)
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.Restrict);

        // PostReport 
        builder.Entity<PostReport>()
            .HasOne(r => r.Post)
            .WithMany(p => p.Reports)
            .HasForeignKey(r => r.PostId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Hashtag>().HasData(
            new Hashtag { Id = 1, Name = "interacthub" },
            new Hashtag { Id = 2, Name = "social" },
            new Hashtag { Id = 3, Name = "news" }
        );
    }
}