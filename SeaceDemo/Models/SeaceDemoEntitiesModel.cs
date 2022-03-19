using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SeaceDemo.Models
{
    public partial class SeaceDemoEntitiesModel : DbContext
    {
        public SeaceDemoEntitiesModel()
            : base("name=SeaceDemoEntitiesModel")
        {
            this.Configuration.LazyLoadingEnabled = false;  
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<PhotoPost> PhotoPosts { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.idUser)
                .IsUnicode(false);

            modelBuilder.Entity<Like>()
                .Property(e => e.idUser)
                .IsUnicode(false);

            modelBuilder.Entity<PhotoPost>()
                .Property(e => e.srcPhotoPost)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.idUser)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Likes)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PhotoPosts)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Story>()
                .Property(e => e.srcImage)
                .IsUnicode(false);

            modelBuilder.Entity<Story>()
                .Property(e => e.idUser)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.idUser)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Likes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
