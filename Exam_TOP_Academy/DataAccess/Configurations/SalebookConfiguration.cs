using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;
internal class SalebookConfiguration : IEntityTypeConfiguration<Salebook>
{
    public void Configure(EntityTypeBuilder<Salebook> builder)
    {
        builder.HasKey(e => e.SaleId).HasName("salebook_pkey");

        builder.ToTable("salebook");

        builder.Property(e => e.SaleId).HasColumnName("sale_id");
        builder.Property(e => e.BookId).HasColumnName("book_id");
        builder.Property(e => e.PromotionId).HasColumnName("promotion_id");

        builder.HasOne(d => d.Book).WithMany(p => p.Salebooks)
            .HasForeignKey(d => d.BookId)
            .HasConstraintName("salebook_book_id_fkey");

        builder.HasOne(d => d.Promotion).WithMany(p => p.Salebooks)
            .HasForeignKey(d => d.PromotionId)
            .HasConstraintName("salebook_promotion_id_fkey");
    }
}
