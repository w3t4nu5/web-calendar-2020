﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using WebCalendar.DAL.Models;
using WebCalendar.DAL.Models.Entity;

namespace WebCalendar.DAL.EF.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        
        public override DbSet<User> Users { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(type.ClrType))
                {
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
                }
            }

            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.ApplyConfiguration<>
        }
        
        public override int SaveChanges()
        {
            OnBeforeSaving();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            ChangeTracker.DetectChanges();

            List<EntityEntry<ISoftDeletable>> deletedEntities = ChangeTracker.Entries<ISoftDeletable>()
                .Where(e => e.State == EntityState.Deleted).ToList();
            deletedEntities.ForEach(e =>
            {
                e.State = EntityState.Unchanged;
                e.Entity.IsDeleted = true;
                
            });

            List<EntityEntry<IEntity>> addedEntities = ChangeTracker.Entries<IEntity>()
                .Where(e => e.State == EntityState.Added).ToList();
            addedEntities.ForEach(e =>
            {
                e.Entity.AddedDate = DateTime.UtcNow;
            });

            List<EntityEntry<IEntity>> modifiedEntities = ChangeTracker.Entries<IEntity>()
                .Where(e => e.State == EntityState.Modified).ToList();
            modifiedEntities.ForEach(e =>
            {
                e.Entity.ModifiedDate = DateTime.UtcNow;
            });
        }
    }
}