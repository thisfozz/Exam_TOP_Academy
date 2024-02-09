using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;

internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(e => e.GenreId).HasName("genre_pkey");

        builder.ToTable("genre");

        builder.HasIndex(e => e.GenreName, "genre_genre_name_key").IsUnique();

        builder.Property(e => e.GenreId).HasColumnName("genre_id");
        builder.Property(e => e.GenreName)
            .HasMaxLength(50)
            .HasColumnName("genre_name");
    }
}
