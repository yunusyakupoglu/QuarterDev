using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ObjAppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ObjAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ObjAppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ObjAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ObjBlogAppUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ObjBlogConfiguration());
            modelBuilder.ApplyConfiguration(new ObjAboutUsConfiguration());
            modelBuilder.ApplyConfiguration(new ObjAUDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new ObjQuarterCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ObjQuarterCategoryTitleConfiguration());
            modelBuilder.ApplyConfiguration(new ObjSubtitleItemConfiguration());
            modelBuilder.ApplyConfiguration(new ObjSubtitleDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new ObjCategorySubtitleConfiguration());
        }

        public DbSet<ObjAppRole> objAppRoles { get; set; }
        public DbSet<ObjAppUser> objAppUsers { get; set; }
        public DbSet<ObjAppUserRole> objAppUserRoles { get; set; }
        public DbSet<ObjBlog> objBlogs { get; set; }
        public DbSet<ObjBlogAppUser> blogAppUsers { get; set; }
        public DbSet<ObjBlogAppUserStatus> blogAppUserStatuses { get; set; }
        public DbSet<ObjAboutUs> aboutUses { get; set; }
        public DbSet<ObjAUDescription> AUDescriptions{ get; set; }
        public DbSet<ObjQuarterCategory> QuarterCategories{ get; set; }
        public DbSet<ObjQuarterCategoryTitle> QuarterCategoryTitles{ get; set; }
        public DbSet<ObjSubtitleItem> SubtitleItems{ get; set; }
        public DbSet<ObjSubtitleDescription> SubtitleDescriptions{ get; set; }
        public DbSet<ObjCategorySubtitle> CategorySubtitles{ get; set; }
    }
}
