﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220212213203_UserImgAdd")]
    partial class UserImgAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OL.ObjAboutUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("aboutUses");
                });

            modelBuilder.Entity("OL.ObjAppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("objAppRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Definition = "SuperAdmin",
                            Status = false
                        },
                        new
                        {
                            Id = 2,
                            Definition = "Admin",
                            Status = false
                        },
                        new
                        {
                            Id = 3,
                            Definition = "Member",
                            Status = false
                        });
                });

            modelBuilder.Entity("OL.ObjAppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("objAppUsers");
                });

            modelBuilder.Entity("OL.ObjAppUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("AppRoleId", "AppUserId")
                        .IsUnique();

                    b.ToTable("objAppUserRoles");
                });

            modelBuilder.Entity("OL.ObjAUDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AboutUsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObjAboutUsId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ObjAboutUsId");

                    b.ToTable("AUDescriptions");
                });

            modelBuilder.Entity("OL.ObjBlog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("objBlogs");
                });

            modelBuilder.Entity("OL.ObjBlogAppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("BlogAppUserStatusId")
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int?>("ObjAppUserId")
                        .HasColumnType("int");

                    b.Property<int?>("ObjBlogAppUserStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("ObjBlogId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObjAppUserId");

                    b.HasIndex("ObjBlogAppUserStatusId");

                    b.HasIndex("ObjBlogId");

                    b.ToTable("blogAppUsers");
                });

            modelBuilder.Entity("OL.ObjBlogAppUserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("blogAppUserStatuses");
                });

            modelBuilder.Entity("OL.ObjCategorySubtitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("ObjQuarterCategoryTitleId")
                        .HasColumnType("int");

                    b.Property<int>("QuarterCategoryTitleId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ObjQuarterCategoryTitleId");

                    b.ToTable("CategorySubtitles");
                });

            modelBuilder.Entity("OL.ObjProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("OL.ObjProjectImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObjProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ObjProjectId");

                    b.ToTable("ProjectImages");
                });

            modelBuilder.Entity("OL.ObjQuarterCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuarterCategories", (string)null);
                });

            modelBuilder.Entity("OL.ObjQuarterCategoryTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObjQuarterCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("QuarterCategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ObjQuarterCategoryId");

                    b.ToTable("QuarterCategoryTitles", (string)null);
                });

            modelBuilder.Entity("OL.ObjSubtitleDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoySubtitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObjCategorySubtitleId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ObjCategorySubtitleId");

                    b.ToTable("SubtitleDescriptions");
                });

            modelBuilder.Entity("OL.ObjSubtitleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoySubtitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObjCategorySubtitleId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ObjCategorySubtitleId");

                    b.ToTable("SubtitleItems");
                });

            modelBuilder.Entity("OL.ObjAppUserRole", b =>
                {
                    b.HasOne("OL.ObjAppRole", "ObjAppRole")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OL.ObjAppUser", "ObjAppUser")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjAppRole");

                    b.Navigation("ObjAppUser");
                });

            modelBuilder.Entity("OL.ObjAUDescription", b =>
                {
                    b.HasOne("OL.ObjAboutUs", "ObjAboutUs")
                        .WithMany("Descriptions")
                        .HasForeignKey("ObjAboutUsId");

                    b.Navigation("ObjAboutUs");
                });

            modelBuilder.Entity("OL.ObjBlogAppUser", b =>
                {
                    b.HasOne("OL.ObjAppUser", "ObjAppUser")
                        .WithMany("BlogAppUsers")
                        .HasForeignKey("ObjAppUserId");

                    b.HasOne("OL.ObjBlogAppUserStatus", "ObjBlogAppUserStatus")
                        .WithMany("BlogAppUsers")
                        .HasForeignKey("ObjBlogAppUserStatusId");

                    b.HasOne("OL.ObjBlog", "ObjBlog")
                        .WithMany()
                        .HasForeignKey("ObjBlogId");

                    b.Navigation("ObjAppUser");

                    b.Navigation("ObjBlog");

                    b.Navigation("ObjBlogAppUserStatus");
                });

            modelBuilder.Entity("OL.ObjCategorySubtitle", b =>
                {
                    b.HasOne("OL.ObjQuarterCategoryTitle", null)
                        .WithMany("Subtitles")
                        .HasForeignKey("ObjQuarterCategoryTitleId");
                });

            modelBuilder.Entity("OL.ObjProjectImage", b =>
                {
                    b.HasOne("OL.ObjProject", null)
                        .WithMany("ProjectImages")
                        .HasForeignKey("ObjProjectId");
                });

            modelBuilder.Entity("OL.ObjQuarterCategoryTitle", b =>
                {
                    b.HasOne("OL.ObjQuarterCategory", null)
                        .WithMany("CategoryTitles")
                        .HasForeignKey("ObjQuarterCategoryId");
                });

            modelBuilder.Entity("OL.ObjSubtitleDescription", b =>
                {
                    b.HasOne("OL.ObjCategorySubtitle", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("ObjCategorySubtitleId");
                });

            modelBuilder.Entity("OL.ObjSubtitleItem", b =>
                {
                    b.HasOne("OL.ObjCategorySubtitle", null)
                        .WithMany("Items")
                        .HasForeignKey("ObjCategorySubtitleId");
                });

            modelBuilder.Entity("OL.ObjAboutUs", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("OL.ObjAppRole", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("OL.ObjAppUser", b =>
                {
                    b.Navigation("AppUserRoles");

                    b.Navigation("BlogAppUsers");
                });

            modelBuilder.Entity("OL.ObjBlogAppUserStatus", b =>
                {
                    b.Navigation("BlogAppUsers");
                });

            modelBuilder.Entity("OL.ObjCategorySubtitle", b =>
                {
                    b.Navigation("Descriptions");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("OL.ObjProject", b =>
                {
                    b.Navigation("ProjectImages");
                });

            modelBuilder.Entity("OL.ObjQuarterCategory", b =>
                {
                    b.Navigation("CategoryTitles");
                });

            modelBuilder.Entity("OL.ObjQuarterCategoryTitle", b =>
                {
                    b.Navigation("Subtitles");
                });
#pragma warning restore 612, 618
        }
    }
}
