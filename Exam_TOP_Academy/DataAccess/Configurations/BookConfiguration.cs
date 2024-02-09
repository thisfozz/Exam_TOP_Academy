using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;
internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(e => e.BookId).HasName("book_pkey");

        builder.ToTable("book");

        builder.Property(e => e.BookId).HasColumnName("book_id");
        builder.Property(e => e.AuthorId).HasColumnName("author_id");
        builder.Property(e => e.Description).HasColumnName("description");
        builder.Property(e => e.GenreId).HasColumnName("genre_id");
        builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
        builder.Property(e => e.Pages).HasColumnName("pages");
        builder.Property(e => e.PublisherId).HasColumnName("publisher_id");
        builder.Property(e => e.SellingPrice)
            .HasPrecision(6, 2)
            .HasColumnName("selling_price");
        builder.Property(e => e.SequelId).HasColumnName("sequel_id");
        builder.Property(e => e.Title)
            .HasMaxLength(100)
            .HasColumnName("title");
        builder.Property(e => e.YearPublished).HasColumnName("year_published");

        builder.HasOne(d => d.Author).WithMany(p => p.Books)
            .HasForeignKey(d => d.AuthorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("book_author_id_fkey");

        builder.HasOne(d => d.Genre).WithMany(p => p.Books)
            .HasForeignKey(d => d.GenreId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("book_genre_id_fkey");

        builder.HasOne(d => d.Publisher).WithMany(p => p.Books)
            .HasForeignKey(d => d.PublisherId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("book_publisher_id_fkey");

        builder.HasOne(d => d.Sequel).WithMany(p => p.InverseSequel)
            .HasForeignKey(d => d.SequelId)
            .HasConstraintName("book_sequel_id_fkey");
    }
}
