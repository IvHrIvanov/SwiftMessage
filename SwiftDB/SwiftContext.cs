using Microsoft.EntityFrameworkCore;
using Swift.Db.EntityConfiguration;
using Swift.Db.Models;
using Swift.Db.Models.Models;
using SwiftDB;

namespace Swift.Db
{
    public class SwiftContext : DbContext
    {
        public SwiftContext() { }

        public SwiftContext(DbContextOptions options)
            : base(options) { }

        public DbSet<FileTxt> FilesTxts { get; set; }

        public DbSet<Transaction> Translations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileTxtConfiguration());
            modelBuilder.ApplyConfiguration(new TranslationConfiguration());
        }
    }
}