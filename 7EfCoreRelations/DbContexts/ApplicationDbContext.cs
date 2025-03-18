using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreRelations.Entities;

namespace EfCoreRelations.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(noteConfig =>
            {
                noteConfig.HasKey(n => n.Id);

                noteConfig.HasIndex(n => n.Title).IsUnique();
                noteConfig.Property(n => n.Title).HasMaxLength(32);
                noteConfig.Property(n => n.Description).HasMaxLength(512);

                noteConfig
                    .HasOne(n => n.User)
                    .WithMany(n => n.Notes)
                    .HasForeignKey(n => n.UserId);
            });

            modelBuilder.Entity<Role>(roleConfig =>
            {
                roleConfig.HasKey(r => r.Id);

                roleConfig.HasIndex(r => r.Title).IsUnique();
                roleConfig.Property(r => r.Title).HasMaxLength(32);
                roleConfig.Property(r => r.Description).HasMaxLength(512);

                roleConfig
                    .HasMany(u => u.Users)
                    .WithMany(u => u.Roles)
                    .UsingEntity<UserRoles>(
                      ur => ur
                           .HasOne(ur => ur.User)
                           .WithMany()
                           .HasForeignKey(ur => ur.UserId),
                      ur => ur
                           .HasOne(ur => ur.Role)
                           .WithMany()
                           .HasForeignKey(ur => ur.RoleId));
                
                roleConfig
                    .HasMany(p => p.Permissions)
                    .WithMany(p => p.Roles)
                    .UsingEntity<RolePermissions>(
                      rp => rp
                           .HasOne(rp => rp.Permission)
                           .WithMany()
                           .HasForeignKey(rp => rp.PermissionId),
                      rp => rp
                           .HasOne(rp => rp.Role)
                           .WithMany()
                           .HasForeignKey(rp => rp.RoleId));
            });

            modelBuilder.Entity<User>(userConfig =>
            {
                userConfig.HasKey(u => u.Id);

                userConfig.HasIndex(u => u.Login).IsUnique();
                userConfig.Property(u => u.Login).HasMaxLength(32);

                userConfig
                    .HasMany(r => r.Roles)
                    .WithMany(r => r.Users)
                    .UsingEntity<UserRoles>(
                      l => l
                           .HasOne(ur => ur.Role)
                           .WithMany()
                           .HasForeignKey(ur => ur.RoleId),
                      r => r
                           .HasOne(ur => ur.User)
                           .WithMany()
                           .HasForeignKey(ur => ur.UserId)
                    );

                userConfig
                    .HasMany(u => u.Notes)
                    .WithOne(n => n.User);
            });

            modelBuilder.Entity<Permission>(permissionConfig =>
            {
                permissionConfig.HasKey(p => p.Id);

                permissionConfig.HasIndex(p => p.Title).IsUnique();
                permissionConfig.Property(p => p.Title).HasMaxLength(32);
                permissionConfig.Property(p => p.Description).HasMaxLength(512);

                permissionConfig
                    .HasMany(r => r.Roles)
                    .WithMany(r => r.Permissions)
                    .UsingEntity<RolePermissions>(
                      rp => rp
                           .HasOne(rp => rp.Role)
                           .WithMany()
                           .HasForeignKey(rp => rp.RoleId),
                      rp => rp
                           .HasOne(rp => rp.Permission)
                           .WithMany()
                           .HasForeignKey(rp => rp.PermissionId)
                    );
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=EfCoreRelations;user=xdsharp;password=123321;", new MySqlServerVersion(new Version(8, 0, 40)));
        }
    }
}