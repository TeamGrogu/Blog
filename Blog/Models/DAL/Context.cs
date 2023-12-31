﻿using Blog.Models.Entities;
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
			builder.Entity<Konu>().HasData(
				new Konu { ID = 1, KonuAdi = "Teknoloji" },
				new Konu { ID = 2, KonuAdi = "Felsefe" },
				new Konu { ID = 3, KonuAdi = "Bilim" },
				new Konu { ID = 4, KonuAdi = "Yazılım" },
				new Konu { ID = 5, KonuAdi = "Kişisel Gelişim" },
				new Konu { ID = 6, KonuAdi = "Film" }
				);
			builder.Entity<Makale>().HasData(
				new Makale { ID = 1, KonuID = 1, Baslik = "1.Makale Başlığı", Icerik = "1. Makale İçeriği" },
				new Makale { ID = 2, KonuID = 2, Baslik = "2.Makale Başlığı", Icerik = "2. Makale İçeriği" },
				new Makale { ID = 3, KonuID = 3, Baslik = "3.Makale Başlığı", Icerik = "3. Makale İçeriği" },
				new Makale { ID = 4, KonuID = 4, Baslik = "4.Makale Başlığı", Icerik = "4. Makale İçeriği" }
				);
			builder.Entity<User>().Property(x => x.Image).HasColumnType("binary");

			builder.Entity<Role>().HasData(
					new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
					new Role { Id = 2, Name = "Standard", NormalizedName = "STANDARD" }
				);

			base.OnModelCreating(builder);
		}
	}
}
