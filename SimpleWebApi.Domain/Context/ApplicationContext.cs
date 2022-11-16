using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Shared.Enumerations;

namespace SimpleWebApi.Domain.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public ApplicationContext()
        {

        }

        //Students

        public virtual DbSet<Student> Students { get; set; }

        //Grade

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        //Relations Between grade and student

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasKey(x => x.Id);

            builder.Entity<Grade>()
                .HasKey(x => x.Id);

            builder.Entity<Student>()
                .HasOne(x => x.Grade)
                .WithMany(x => x.Students);
            //Primary Key
            // Foreign key
        }

        public override int SaveChanges()
        {
            var commonObjectSet = ChangeTracker.Entries<BaseEntity>()
                                               .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified )
                                               .ToList();

            if(commonObjectSet != null)
            {
                foreach (var entry in commonObjectSet)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.Status = EntityStatus.Active;
                            entry.Entity.CreateDate = DateTime.Now;
                            entry.Entity.LastModifiedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModifiedDate = DateTime.Now;
                            break;
                    }
                }
            }
            int result = base.SaveChanges();
            return result;
        }

        #region Commit for error handling in SaveChanges Methods
        //Sneak Peek
        //public void Commit()
        //{
        //    try
        //    {
        //        this.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex);
        //        throw ex;
        //    }
        //} 
        #endregion

    }
}
