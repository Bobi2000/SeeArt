using Art.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Art.Data
{
    public class ArtDbContext : IdentityDbContext<User>
    {
        public ArtDbContext()
        {
        }

        public ArtDbContext(DbContextOptions<ArtDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source=DESKTOP-U0L94FK\SQLEXPRESS;Database=Art;Integrated Security=True");
            }

            base.OnConfiguring(options);
        }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<UserFollower> Followers { get; set; }

        public DbSet<UserLikedPicture> UserLikedPictures { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PictureTag> PictureTag { get; set; }

        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<Comic> Comics { get; set; }

        public DbSet<ComicTag> ComicTags { get; set; }

        public DbSet<ChapterPicture> ChapterPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(f => f.Followers)
                .WithOne(f => f.FollowerUser)
                .HasForeignKey(f => f.FollowerId);

            modelBuilder.Entity<UserFollower>()
                .HasKey(t => new { t.FollowedId, t.FollowerId });

            modelBuilder.Entity<User>()
                .HasMany(p => p.LikedPictures)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserLikedPicture>()
                .HasKey(p => new { p.PictureId, p.UserId });

            modelBuilder.Entity<Picture>()
                .HasMany(t => t.Tags)
                .WithOne(t => t.Picture)
                .HasForeignKey(t => t.PictureId);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.Pictures)
                .WithOne(t => t.Tag)
                .HasForeignKey(t => t.TagId);

            modelBuilder.Entity<PictureTag>()
                .HasKey(p => new { p.PictureId, p.TagId });

            modelBuilder.Entity<Chapter>()
                .HasMany(c => c.Pictures)
                .WithOne(c => c.Chapter)
                .HasForeignKey(c => c.ChapterId);

            modelBuilder.Entity<ChapterPicture>()
                .HasKey(cp => new { cp.ChapterId, cp.PictureId });

            modelBuilder.Entity<Comic>()
                .HasMany(c => c.Tags)
                .WithOne(c => c.Comic)
                .HasForeignKey(c => c.ComicId);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.Comics)
                .WithOne(t => t.Tag)
                .HasForeignKey(t => t.TagId);

            modelBuilder.Entity<ComicTag>()
                .HasKey(ct => new { ct.ComicId, ct.TagId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
