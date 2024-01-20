﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Schronisko.Data;

#nullable disable

namespace Schronisko.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Schronisko.Models.AdoptionForm", b =>
                {
                    b.Property<int>("FormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormId"), 1L, 1);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer10")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Answer11")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Answer12")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Answer14")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("Answer15")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("Answer16")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("Answer17")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("Answer18")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("Answer19")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Answer20")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("Answer21")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("Answer22")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Answer23")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Answer24")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Answer4")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Answer5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer6")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer7")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer8")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer9")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormId");

                    b.ToTable("AdoptionForms");
                });

            modelBuilder.Entity("Schronisko.Models.Animal", b =>
                {
                    b.Property<int>("AnimalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalID"), 1L, 1);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdoptowanyPrzez")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnimalTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<bool>("Dostepnosc")
                        .HasColumnType("bit");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Photo")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalID");

                    b.HasIndex("AnimalTypeID");

                    b.HasIndex("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Schronisko.Models.AnimalType", b =>
                {
                    b.Property<int>("AnimalTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalTypeID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AnimalTypeID");

                    b.ToTable("AnimalTypes");
                });

            modelBuilder.Entity("Schronisko.Models.Announcement", b =>
                {
                    b.Property<int>("AnnouncementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnnouncementID"), 1L, 1);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AnnouncementText")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Photo")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnnouncementID");

                    b.HasIndex("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Schronisko.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NewsId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("CommentId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("AnnouncementId");

                    b.HasIndex("Id");

                    b.HasIndex("NewsId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Schronisko.Models.News", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsID"), 1L, 1);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NewsText")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("Photo")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("NewsID");

                    b.HasIndex("Id");

                    b.ToTable("Newses");
                });

            modelBuilder.Entity("Schronisko.Models.ResponseUserForm", b =>
                {
                    b.Property<int>("ResponseUserFormID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponseUserFormID"), 1L, 1);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UserFormID")
                        .HasColumnType("int");

                    b.Property<int>("UserFormTypeID")
                        .HasColumnType("int");

                    b.HasKey("ResponseUserFormID");

                    b.HasIndex("Id");

                    b.HasIndex("UserFormID");

                    b.ToTable("ResponseUserForms");
                });

            modelBuilder.Entity("Schronisko.Models.ResponseUserFormQuestion", b =>
                {
                    b.Property<int>("ResponseUserFormQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponseUserFormQuestionID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<int?>("QuestionOrder")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ResponseUserFormID")
                        .HasColumnType("int");

                    b.Property<int>("UserFormQuestionID")
                        .HasColumnType("int");

                    b.Property<int>("UserFormQuestionTypeID")
                        .HasColumnType("int");

                    b.HasKey("ResponseUserFormQuestionID");

                    b.HasIndex("ResponseUserFormID");

                    b.ToTable("ResponseUserFormQuestions");
                });

            modelBuilder.Entity("Schronisko.Models.ResponseUserFormQuestionOption", b =>
                {
                    b.Property<int>("ResponseUserFormQuestionOptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponseUserFormQuestionOptionID"), 1L, 1);

                    b.Property<bool>("Checked")
                        .HasColumnType("bit");

                    b.Property<int?>("OptionOrder")
                        .HasColumnType("int");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ResponseUserFormQuestionID")
                        .HasColumnType("int");

                    b.Property<int>("UserFormQuestionOptionID")
                        .HasColumnType("int");

                    b.HasKey("ResponseUserFormQuestionOptionID");

                    b.HasIndex("ResponseUserFormQuestionID");

                    b.ToTable("ResponseUserFormQuestionOptions");
                });

            modelBuilder.Entity("Schronisko.Models.UserForm", b =>
                {
                    b.Property<int>("UserFormID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFormID"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UserFormTypeID")
                        .HasColumnType("int");

                    b.HasKey("UserFormID");

                    b.HasIndex("Id");

                    b.HasIndex("UserFormTypeID");

                    b.ToTable("UserForms");
                });

            modelBuilder.Entity("Schronisko.Models.UserFormQuestion", b =>
                {
                    b.Property<int>("UserFormQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFormQuestionID"), 1L, 1);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("QuestionOrder")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserFormID")
                        .HasColumnType("int");

                    b.Property<int>("UserFormQuestionTypeID")
                        .HasColumnType("int");

                    b.HasKey("UserFormQuestionID");

                    b.HasIndex("Id");

                    b.HasIndex("UserFormID");

                    b.HasIndex("UserFormQuestionTypeID");

                    b.ToTable("UserFormQuestions");
                });

            modelBuilder.Entity("Schronisko.Models.UserFormQuestionOption", b =>
                {
                    b.Property<int>("UserFormQuestionOptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFormQuestionOptionID"), 1L, 1);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("OptionOrder")
                        .HasColumnType("int");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserFormQuestionID")
                        .HasColumnType("int");

                    b.HasKey("UserFormQuestionOptionID");

                    b.HasIndex("Id");

                    b.HasIndex("UserFormQuestionID");

                    b.ToTable("UserFormQuestionOptions");
                });

            modelBuilder.Entity("Schronisko.Models.UserFormQuestionType", b =>
                {
                    b.Property<int>("UserFormQuestionTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFormQuestionTypeID"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("UserFormQuestionTypeID");

                    b.ToTable("UserFormQuestionTypes");
                });

            modelBuilder.Entity("Schronisko.Models.UserFormType", b =>
                {
                    b.Property<int>("FormTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormTypeID"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("FormTypeID");

                    b.ToTable("UserFormTypes");
                });

            modelBuilder.Entity("Schronisko.Models.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Information")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Schronisko.Models.Animal", b =>
                {
                    b.HasOne("Schronisko.Models.AnimalType", "AnimalType")
                        .WithMany()
                        .HasForeignKey("AnimalTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schronisko.Models.AppUser", "User")
                        .WithMany("Animals")
                        .HasForeignKey("Id");

                    b.Navigation("AnimalType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schronisko.Models.Announcement", b =>
                {
                    b.HasOne("Schronisko.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schronisko.Models.Comment", b =>
                {
                    b.HasOne("Schronisko.Models.Animal", "Animal")
                        .WithMany("Comments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schronisko.Models.Announcement", "Announcement")
                        .WithMany("Comments")
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schronisko.Models.AppUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schronisko.Models.News", "News")
                        .WithMany("Comments")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Announcement");

                    b.Navigation("News");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schronisko.Models.News", b =>
                {
                    b.HasOne("Schronisko.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schronisko.Models.ResponseUserForm", b =>
                {
                    b.HasOne("Schronisko.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.HasOne("Schronisko.Models.UserForm", null)
                        .WithMany("Responses")
                        .HasForeignKey("UserFormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schronisko.Models.ResponseUserFormQuestion", b =>
                {
                    b.HasOne("Schronisko.Models.ResponseUserForm", "ResponseForm")
                        .WithMany("ResponseQuestions")
                        .HasForeignKey("ResponseUserFormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResponseForm");
                });

            modelBuilder.Entity("Schronisko.Models.ResponseUserFormQuestionOption", b =>
                {
                    b.HasOne("Schronisko.Models.ResponseUserFormQuestion", "ResponseQuestion")
                        .WithMany("ResponseOptions")
                        .HasForeignKey("ResponseUserFormQuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResponseQuestion");
                });

            modelBuilder.Entity("Schronisko.Models.UserForm", b =>
                {
                    b.HasOne("Schronisko.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.HasOne("Schronisko.Models.UserFormType", "FormType")
                        .WithMany()
                        .HasForeignKey("UserFormTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schronisko.Models.UserFormQuestion", b =>
                {
                    b.HasOne("Schronisko.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.HasOne("Schronisko.Models.UserForm", "Form")
                        .WithMany("Questions")
                        .HasForeignKey("UserFormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schronisko.Models.UserFormQuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("UserFormQuestionTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("QuestionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schronisko.Models.UserFormQuestionOption", b =>
                {
                    b.HasOne("Schronisko.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.HasOne("Schronisko.Models.UserFormQuestion", "Question")
                        .WithMany("Options")
                        .HasForeignKey("UserFormQuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schronisko.Models.Animal", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Schronisko.Models.Announcement", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Schronisko.Models.News", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Schronisko.Models.ResponseUserForm", b =>
                {
                    b.Navigation("ResponseQuestions");
                });

            modelBuilder.Entity("Schronisko.Models.ResponseUserFormQuestion", b =>
                {
                    b.Navigation("ResponseOptions");
                });

            modelBuilder.Entity("Schronisko.Models.UserForm", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Responses");
                });

            modelBuilder.Entity("Schronisko.Models.UserFormQuestion", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Schronisko.Models.AppUser", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
