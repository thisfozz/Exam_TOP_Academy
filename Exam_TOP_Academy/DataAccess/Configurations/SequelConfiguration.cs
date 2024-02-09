using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;
internal class SequelConfiguration : IEntityTypeConfiguration<Sequel>
{
    public void Configure(EntityTypeBuilder<Sequel> builder)
    {
        builder.HasKey(e => e.SequelId).HasName("sequels_pkey");

        builder.ToTable("sequels");

        builder.Property(e => e.SequelId).HasColumnName("sequel_id");
        builder.Property(e => e.ContinuationTitle)
            .HasMaxLength(100)
            .HasColumnName("continuation_title");
        builder.Property(e => e.OriginalBookId).HasColumnName("original_book_id");

        builder.HasOne(d => d.OriginalBook).WithMany(p => p.Sequels)
            .HasForeignKey(d => d.OriginalBookId)
            .HasConstraintName("sequels_original_book_id_fkey");
    }
}
