using Alimzfr.DomainLayer.AuthEntities;
using Alimzfr.DomainLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alimzfr.DataLayer.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option): base(option)
        {
        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<TrainingCourse> TrainingCourses { get; set; }
        public DbSet<CollegeEducation> CollegeEducations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(builder);

            // Custom application mappings
            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.SerialNumber).HasMaxLength(450);
                entity.Property(e => e.Username).HasMaxLength(450);
            });

            builder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.RoleId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.RoleId);
                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
                entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
            });

            builder.Entity<UserToken>(entity =>
            {
                entity.HasOne(ut => ut.User)
                      .WithMany(u => u.UserTokens)
                      .HasForeignKey(ut => ut.UserId);

                entity.Property(ut => ut.RefreshTokenIdHash).HasMaxLength(450).IsRequired();
                entity.Property(ut => ut.RefreshTokenIdHashSource).HasMaxLength(450);
            });
        }
    }
}
