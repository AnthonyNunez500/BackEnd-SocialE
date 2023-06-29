﻿using BackEnd_SocialE.Learning.Domain.Models;
using BackEnd_SocialE.Security.Domain.Models;
using BackEnd_SocialE.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SocialE.Shared.Persistence.Contexts;

public class AppDbContext : DbContext {
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Event>().ToTable("Events");
        modelBuilder.Entity<Event>().HasKey(p=>p.Id);
        modelBuilder.Entity<Event>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Event>().Property(p => p.Name).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.Description).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.Price).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.EventDate).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.StartTime).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<Event>().Property(p => p.EndTime).IsRequired().HasMaxLength(120);
        //Añadir relaciones
        
        
        //Usuarios
        // Constraints
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(p => p.Id);
        modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(120);
        modelBuilder.Entity<User>().Property(p => p.Type).IsRequired().HasMaxLength(120);
        //Cambiar syntax
        modelBuilder.UseSnakeCaseNamingConvention();
    }
}