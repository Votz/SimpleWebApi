using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Shared.Enumerations;

namespace SimpleWebApi.Domain.Context
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public ApplicationContext()
        {

        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Student>()
                .HasKey(x => x.Id);

            builder.Entity<Grade>()
                .HasKey(x => x.Id);

            builder.Entity<Student>()
                .HasOne(x => x.Grade)
                .WithMany(x => x.Students);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var commonObjectSet = ChangeTracker.Entries<BaseEntity>()
                                               .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                                               .ToList();

            if (commonObjectSet != null)
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
    }
}
