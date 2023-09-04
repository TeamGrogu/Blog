using Blog.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Blog.Models.DAL
{
    public class Context : IdentityDbContext<User, Role, int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Konu> Konus { get; set; }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMakale> UserMakales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(x => x.Image).HasColumnType("binary");

            builder.Entity<Role>().HasData(
                    new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                    new Role { Id = 2, Name = "Standard", NormalizedName = "STANDARD" }
                );

            base.OnModelCreating(builder);
        }
    }
}
