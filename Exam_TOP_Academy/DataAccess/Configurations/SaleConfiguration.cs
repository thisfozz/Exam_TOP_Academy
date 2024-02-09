using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;

internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(e => e.SalesId).HasName("sales_pkey");

        builder.ToTable("sales");

        builder.Property(e => e.SalesId).HasColumnName("sales_id");
        builder.Property(e => e.BookId).HasColumnName("book_id");
        builder.Property(e => e.QuantitySold).HasColumnName("quantity_sold");
        builder.Property(e => e.SalesDate).HasColumnName("sales_date");

        builder.HasOne(d => d.Book).WithMany(p => p.Sales)
            .HasForeignKey(d => d.BookId)
            .HasConstraintName("sales_book_id_fkey");
    }
}
