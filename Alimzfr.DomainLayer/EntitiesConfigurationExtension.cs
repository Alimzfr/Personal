using System;
using System.Collections.Generic;
using System.Text;
using Alimzfr.DomainLayer.AuthEntities;
using Alimzfr.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alimzfr.DomainLayer
{
    public static class EntitiesConfigurationExtension
    {
        public static void EntitiesConfiguration(this ModelBuilder builder)
        {
            if (builder == null) return;

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

            builder.Entity<UserMessage>(entity =>
            {
                entity.HasIndex(e => e.CreatDate);
                entity.HasIndex(e => e.Email);
                entity.HasIndex(e => e.IsRead);
            });
        }
    }
}
