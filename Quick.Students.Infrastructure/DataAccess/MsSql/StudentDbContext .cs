using Microsoft.EntityFrameworkCore;
using Quick.Students.Domain.Entities;

namespace Quick.Students.Infrastructure.DataAccess.MsSql
{
public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<GuardianType> GuardianTypes { get; set; }
        public DbSet<Guardian> Guardians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Family>()
                .HasIndex(x => x.Code)
                .IsUnique();
        }
    }
}