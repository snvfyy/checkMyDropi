using CheckMyDropi.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace CheckMyDropi.Api.Data.Context
{
    public partial class DroppyContext : DbContext
    {
        public DroppyContext()
        {

        }

        public DroppyContext(DbContextOptions<DroppyContext> options) : base(options)
        {

        }

        public virtual DbSet<MaliciousLink> MaliciousLink { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=TestDatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaliciousLink>(entity => entity.ToTable("MaliciousLinks"));
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
