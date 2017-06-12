using Microsoft.EntityFrameworkCore;
using PharmacyCore.Models;

namespace PharmacyCore.DBContexts
{
    public class PharmacyContext : DbContext
    {

        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        {

        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<User> User { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Medicine>().ToTable("Medicine");
        //}
    }
}
