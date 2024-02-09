using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.CustomerId).HasName("customer_pkey");

        builder.ToTable("customer");

        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.FirstName)
            .HasMaxLength(50)
            .HasColumnName("first_name");
        builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .HasColumnName("last_name");
    }
}
