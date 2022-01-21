using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swift.Db.Models;

namespace Swift.Db.EntityConfiguration
{
    internal class FileTxtConfiguration : IEntityTypeConfiguration<FileTxt>
    {
        public void Configure(EntityTypeBuilder<FileTxt> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(true);

            builder.Property(e => e.Time)
                .IsRequired(true);

            builder.Property(e => e.TransactionCount)
                .IsRequired(true);
        }
    }
}