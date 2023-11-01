using IPMEDTH.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IPMEDTH.Domain.Infrastructure.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }



        #region DbSets
        public DbSet<ScoreEntity> Scores { get; set; } = null!;
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
        #endregion

    }
}
