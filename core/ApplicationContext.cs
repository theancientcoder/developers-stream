﻿using System.Linq;
using core.Models;
using Microsoft.EntityFrameworkCore;

namespace core
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        IQueryable<AvailableTechnology> IApplicationContext.AvailableTechnologies => AvailableTechnologies;
        IQueryable<Streamer> IApplicationContext.Streamers => Streamers;
        IQueryable<StreamerPlatform> IApplicationContext.StreamerPlatforms => StreamerPlatforms;
        IQueryable<StreamerTechnology> IApplicationContext.StreamerTechnologies => StreamerTechnologies;

        public DbSet<AvailableTechnology> AvailableTechnologies { get; set; }
        public DbSet<Streamer> Streamers { get; set; }
        public DbSet<StreamerPlatform> StreamerPlatforms { get; set; }
        public DbSet<StreamerTechnology> StreamerTechnologies { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AvailableTechnology>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<AvailableTechnology>()
                .Property(p => p.Id)
                .HasDefaultValueSql("newid()");
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            Remove(entity);
        }
    }
}