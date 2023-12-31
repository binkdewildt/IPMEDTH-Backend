﻿using IPMEDTH.Domain.Core.Entities;
using IPMEDTH.Domain.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IPMEDTH.Domain.Infrastructure.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }



        #region DbSets
        public DbSet<ScoreEntity> Scores { get; set; } = null!;

        public DbSet<TestingEntity> Testings { get; set; } = null!;
        #endregion



        #region Override
        /// <summary>
        /// SaveChanges valideert nu ook eerst het model.
        /// Op deze manier kan het saven dus ook fout gaan.
        /// </summary>
        public override int SaveChanges()
        {

            // Selecteer de entitites die gevalideerd moeten worden, dit zijn dus of toegevoegde of aangepaste entries
            var entititesToBeValidated = from e in ChangeTracker.Entries()
                                         where e.State == EntityState.Added
                                             || e.State == EntityState.Modified
                                         select e.Entity;


            foreach (var entity in entititesToBeValidated)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(
                    entity,
                    validationContext,
                    validateAllProperties: true);
            }

            return base.SaveChanges();
        }


        /// <summary>
        /// De TestingEntity niet meenemen in de migrations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestingEntity>().ToTable(nameof(Testings), t => t.ExcludeFromMigrations(true));
        }
        #endregion

    }
}
