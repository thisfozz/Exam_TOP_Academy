using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;
internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(e => e.AuthorId).HasName("author_pkey");

        builder.ToTable("author");

        builder.Property(e => e.AuthorId).HasColumnName("author_id");
        builder.Property(e => e.FirstName)
            .HasMaxLength(50)
            .HasColumnName("first_name");
        builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .HasColumnName("last_name");
        builder.Property(e => e.MiddleName)
            .HasMaxLength(50)
            .HasColumnName("middle_name");
    }
}
