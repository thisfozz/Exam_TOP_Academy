using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;
internal class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasKey(e => e.PublisherId).HasName("publisher_pkey");

        builder.ToTable("publisher");

        builder.HasIndex(e => e.PublisherName, "publisher_publisher_name_key").IsUnique();

        builder.Property(e => e.PublisherId).HasColumnName("publisher_id");
        builder.Property(e => e.PublisherName)
            .HasMaxLength(100)
            .HasColumnName("publisher_name");
    }
}
