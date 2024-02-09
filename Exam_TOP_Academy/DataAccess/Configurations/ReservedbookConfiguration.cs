using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;
internal class ReservedbookConfiguration : IEntityTypeConfiguration<Reservedbook>
{
    public void Configure(EntityTypeBuilder<Reservedbook> builder)
    {
        builder.HasKey(e => e.ReserveId).HasName("reservedbook_pkey");

        builder.ToTable("reservedbook");

        builder.Property(e => e.ReserveId).HasColumnName("reserve_id");
        builder.Property(e => e.BookId).HasColumnName("book_id");
        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.IsActiveReserved).HasColumnName("is_active_reserved");
        builder.Property(e => e.ReserveDate).HasColumnName("reserve_date");

        builder.HasOne(d => d.Book).WithMany(p => p.Reservedbooks)
            .HasForeignKey(d => d.BookId)
            .HasConstraintName("reservedbook_book_id_fkey");

        builder.HasOne(d => d.Customer).WithMany(p => p.Reservedbooks)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("reservedbook_customer_id_fkey");
    }
}
