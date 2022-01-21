using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swift.Db.Models.Models;

namespace Swift.Db.EntityConfiguration
{
    internal class TranslationConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Amount)
                .HasMaxLength(15)
                .IsRequired(true);
            builder.Property(e => e.Currency)
                .IsRequired(true);
            builder.Property(e => e.Reason)
                .HasMaxLength(35)
              .IsRequired(true);
            builder.Property(e => e.SenderName)
                .IsRequired(true)
                 .HasMaxLength(60);
            builder.Property(e => e.BICSender)
                .HasMaxLength(12)
                .IsRequired(true);
            builder.Property(e => e.SenderBankAccount)
                .IsRequired(true);
            builder.Property(e => e.RecieverName)
                .IsRequired(true)
                .HasMaxLength(60);
            builder.Property(e => e.BICReciever)
                .HasMaxLength(12)
                .IsRequired(true);
            builder.Property(e => e.RecieverBankAccount)
                .IsRequired(true);
            builder.Property(e => e.SenderBankAccount)
                .IsRequired(true);

            builder.HasOne(e => e.File)
                .WithMany(e => e.Transactions)
                .HasForeignKey(f => f.FileId);
        }
    }
}