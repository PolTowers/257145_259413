﻿using System;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Drawing;

namespace DataAccess;

public class ApplicationContext: DbContext
{
	public DbSet<Client> clients { get; set; }

	public DbSet<Figure> figures { get; set; }

	public DbSet<Material> materials { get; set; }

	public DbSet<Model> models { get; set; }

	public DbSet<PositionedModel> positionedModels { get; set; }

	public DbSet<Scene> scenes { get; set; }


	public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) {	}
	// para migraciones el -v te da los logs
	//dotnet ef migrations add CreateUsers -v

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Material>()
		.Property(m => m.color)
		.HasConversion(
			c => c.ToArgb(),
			c => Color.FromArgb(c)
		)
		.HasColumnName("Color");
	}
}
