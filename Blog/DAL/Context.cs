﻿using Blog.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Blog.DAL
{
    public class Context :  IdentityDbContext<User, Role, int>
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
            builder.Entity<Konu>().HasData(
                new Konu { ID = 1, KonuAdi = "Teknoloji" },
                new Konu { ID = 2, KonuAdi = "Felsefe" },
                new Konu { ID = 3, KonuAdi = "Bilim" },
                new Konu { ID = 4, KonuAdi = "Yazılım" },
                new Konu { ID = 5, KonuAdi = "Kişisel Gelişim" },
                new Konu { ID = 6, KonuAdi = "Film" }
                );
            builder.Entity<User>().Property(x => x.Image).HasColumnType("binary");

            base.OnModelCreating(builder);
        }
    }
}
