using Microsoft.EntityFrameworkCore;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace DataImporterTool.Importer
{
    public class OldStatisticsDbContext : DbContext
    {
        public OldStatisticsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AccountInfo> AccountInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountInfo>().HasKey(a => a.AccountId);
            modelBuilder.Entity<AccountInfo>().Ignore(a => a.Realm);
            modelBuilder.Entity<AccountInfo>().Ignore(a => a.UpdatedAt);
            base.OnModelCreating(modelBuilder);
        }
    }
}