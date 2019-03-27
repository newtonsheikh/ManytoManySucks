using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserGhotala.Data.Models;

namespace UserGhotala.Data
{
    public class UserContext : DbContext
    {
   

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = UserGhotala; Trusted_Connection = True;");
        }

        //public UserContext(DbContextOptions options, UserContext userContext) : base(options)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserRole>().
                HasKey(s => new { s.RoleId, s.UserId });

            modelBuilder.Entity<UserRole>()
                    .HasOne<User>(sc => sc.User)
                    .WithMany(s => s.UserRoles)
                    .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserRole>()
                .HasOne<Role>(sc => sc.Role)
                .WithMany(s => s.UserRoles)
                .HasForeignKey(sc => sc.RoleId);

        }
    }
}
