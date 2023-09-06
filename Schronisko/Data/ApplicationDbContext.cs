using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schronisko.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Schronisko.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Announcement>? Announcements { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<News>? Newses { get; set; }
        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<AnimalType>? AnimalTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Animal>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.Animal);
            modelbuilder.Entity<Announcement>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Announcement);
            modelbuilder.Entity<News>()
                .HasMany(n => n.Comments)
                .WithOne(c => c.News);

            modelbuilder.Entity<Comment>()
                .HasOne(c => c.Animal)
                .WithMany(a => a.Comments);
            modelbuilder.Entity<Comment>()
                .HasOne(c => c.Announcement)
                .WithMany(t => t.Comments);
            modelbuilder.Entity<Comment>()
                .HasOne(c => c.News)
                .WithMany(n => n.Comments);


            //modelbuilder.Entity<Animal>()
            //    .HasOne(t => t.AnimalType)
            //    .WithMany(a => a.Animals);
            //modelbuilder.Entity<AnimalType>()
            //    .HasMany(a => a.Animals)
            //    .WithOne(t => t.AnimalType);
        }
    }
}