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
        public DbSet<AdoptionForm>? AdoptionForms { get; set; }


        public DbSet<UserForm>? UserForms { get; set; }
        public DbSet<UserFormType>? UserFormTypes { get; set; }
        public DbSet<UserFormQuestion>? UserFormQuestions { get; set; }
        public DbSet<UserFormQuestionType>? UserFormQuestionTypes { get; set; }
        public DbSet<UserFormQuestionOption>? UserFormQuestionOptions { get; set; }

        public DbSet<ResponseUserForm>? ResponseUserForms { get; set; }
        public DbSet<ResponseUserFormQuestion>? ResponseUserFormQuestions { get; set; }
        public DbSet<ResponseUserFormQuestionOption>? ResponseUserFormQuestionOptions { get; set; }

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

            modelbuilder.Entity<UserForm>()
                .HasOne(c => c.FormType);
            modelbuilder.Entity<UserForm>()
                .HasMany(n => n.Questions)
                .WithOne(c => c.Form);
            modelbuilder.Entity<UserFormQuestion>()
                .HasOne(c => c.QuestionType);
            modelbuilder.Entity<UserFormQuestion>()
                .HasOne(n => n.Form)
                .WithMany(c => c.Questions);
            modelbuilder.Entity<UserFormQuestion>()
                .HasMany(n => n.Options)
                .WithOne(c => c.Question);
            modelbuilder.Entity<UserFormQuestionOption>()
                .HasOne(n => n.Question)
                .WithMany(c => c.Options);

            //modelbuilder.Entity<ResponseUserForm>()
            //    .HasOne(c => c.FormType);
            modelbuilder.Entity<ResponseUserForm>()
                .HasMany(n => n.ResponseQuestions)
                .WithOne(c => c.ResponseForm);
            //modelbuilder.Entity<ResponseUserFormQuestion>()
            //    .HasOne(c => c.QuestionType);
            modelbuilder.Entity<ResponseUserFormQuestion>()
                .HasOne(n => n.ResponseForm)
                .WithMany(c => c.ResponseQuestions);
            modelbuilder.Entity<ResponseUserFormQuestion>()
                .HasMany(n => n.ResponseOptions)
                .WithOne(c => c.ResponseQuestion);
            modelbuilder.Entity<ResponseUserFormQuestionOption>()
                .HasOne(n => n.ResponseQuestion)
                .WithMany(c => c.ResponseOptions);


            //modelbuilder.Entity<Animal>()
            //    .HasOne(t => t.AnimalType)
            //    .WithMany(a => a.Animals);
            //modelbuilder.Entity<AnimalType>()
            //    .HasMany(a => a.Animals)
            //    .WithOne(t => t.AnimalType);
        }
    }
}